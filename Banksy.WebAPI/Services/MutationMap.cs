using Banksy.WebAPI.Models;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banksy.WebAPI.Services
{
    public class MutationMap : ClassMap<Mutation>
    {
        public MutationMap()
        {
            Map(m => m.Id).Ignore();
            Map(m => m.Date).Name("Datum").TypeConverterOption.Format("yyyymmdd");
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

	//public class CustomDateTimeConverter : DateTimeConverter
	//{
	//	public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
	//	{
	//		try
	//		{
	//			return base.ConvertFromString(text, row, memberMapData);
	//		}
	//		catch (TypeConverterException)
	//		{
	//			return default(DateTime);
	//		}
	//		catch
	//		{
	//			throw;
	//		}
	//	}
	//}
}
