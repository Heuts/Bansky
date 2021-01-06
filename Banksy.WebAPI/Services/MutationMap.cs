using Banksy.WebAPI.Models;
using CsvHelper.Configuration;

namespace Banksy.WebAPI.Services
{
    public class MutationMap : ClassMap<Mutation>
    {
        public MutationMap()
        {
            Map(m => m.Id).Ignore();
            Map(m => m.Date).Name("Datum").TypeConverterOption.Format("yyyyMMdd");
			Map(m => m.Name).Name("Naam / Omschrijving");
            Map(m => m.AccountNumber).Name("Rekening");
            Map(m => m.ContraAccount).Name("Tegenrekening");
            Map(m => m.Code).Name("Code");
            Map(m => m.DebitCredit).Name("Af Bij");
            Map(m => m.Amount).Name("Bedrag (EUR)");
            Map(m => m.MutationType).Name("MutatieSoort");
            Map(m => m.Description).Name("Mededelingen");
        }
    }
}
