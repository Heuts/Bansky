using Banksy.WebAPI.Data;
using Banksy.WebAPI.Models;
using Banksy.WebAPI.Services.Interfaces;
using CsvHelper;
using Microsoft.AspNetCore.Http;
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
        private IMutationsService mutationService;

        public ImportService(BanksyContext context, IMutationsService mutationService)
        {
            this.context = context;
            this.mutationService = mutationService;
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

                List<Mutation> mutations = csv.GetRecords<Mutation>().ToList();

                List<Mutation> mutationsToAdd = await mutationService.RemoveDuplicates(mutations);

                await context.Mutations.AddRangeAsync(mutationsToAdd);
                await context.SaveChangesAsync();

                return mutationsToAdd.Count;
            }
        }
    }
}
