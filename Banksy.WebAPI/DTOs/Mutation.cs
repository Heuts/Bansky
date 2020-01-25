using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banksy.WebAPI.DTOs
{
    public class Mutation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string ContraAccount { get; set; }
        public string Code { get; set; }
        public string DebitCredit { get; set; }
        public double Amount { get; set; }
        public string MutationType { get; set; }
        public string Description { get; set; }
    }
}
