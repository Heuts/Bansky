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
        public void ImportExcel(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                TextReader textReader = new StreamReader(memoryStream);
                var csv = new CsvReader(textReader, new CultureInfo("nl-NL"));
                csv.Configuration.RegisterClassMap<MutationMap>();
                csv.Configuration.Delimiter = ",";

                var records = csv.GetRecords<Mutation>();

            }
        }
    }
}
