using Banksy.WebAPI.Data;
using Banksy.WebAPI.Models;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Banksy.WebAPI.Services
{
    public class ImportService : IImportService
    {
        private BanksyContext context;
        public ImportService(BanksyContext context)
        {
            this.context = context;
        }

        public async Task<int> ImportExcel(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                TextReader textReader = new StreamReader(memoryStream);
                var csv = new CsvReader(textReader, new CultureInfo("nl-NL"));
                csv.Configuration.RegisterClassMap<MutationMap>();
                csv.Configuration.Delimiter = ",";

                Mutation[] mutations = csv.GetRecords<Mutation>().ToArray();

                await context.Mutations.AddRangeAsync(mutations);
                await context.SaveChangesAsync();

                int count = mutations.Length;
                return count;
            }
        }
    }
}
