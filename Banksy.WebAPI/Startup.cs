using System;
using AutoMapper;
using Banksy.WebAPI.Data;
using Banksy.WebAPI.Services;
using Banksy.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Banksy.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string webApiConnectionString = Configuration.GetConnectionString("BanksyApiDBConnectionString");

            Func<string, Action<DbContextOptionsBuilder>> optionActionCreator = connectionString =>
            {
                return options => options.UseSqlServer(connectionString);
            };

            services.AddDbContext<BanksyContext>(optionActionCreator(webApiConnectionString));
            services.AddScoped<IImportService, ImportService>();
            services.AddScoped<IMutationService, MutationService>();
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                policy =>
                {
                    policy.WithOrigins(Configuration.GetSection("Web:SchemeAndHost").Value)
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(config.CreateMapper());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
