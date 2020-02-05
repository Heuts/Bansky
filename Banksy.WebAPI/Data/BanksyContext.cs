using Banksy.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banksy.WebAPI.Data
{
    public class BanksyContext : DbContext
    {
        public DbSet<Mutation> Mutations { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1 ,Name = "Housing" },
                new Category { Id = 2, Name = "Transportation" },
                new Category { Id = 3, Name = "Groceries" },
                new Category { Id = 4, Name = "Utilities" },
                new Category { Id = 5, Name = "Insurance" },
                new Category { Id = 6, Name = "Medical and Healthcare" },
                new Category { Id = 7, Name = "Saving, Investing and Debt payments" },
                new Category { Id = 8, Name = "Personal spending" },
                new Category { Id = 9, Name = "Recreation and Entertainment" },
                new Category { Id = 10, Name = "Miscellaneous" }
                );
        }

        public BanksyContext() : this(new DbContextOptions<BanksyContext>()) { }

        public BanksyContext(DbContextOptions<BanksyContext> options) : base(options) { }
    }
}
