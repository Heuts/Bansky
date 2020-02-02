using System;
using System.Diagnostics.CodeAnalysis;

namespace Banksy.WebAPI.Models
{
    public class Mutation : IEquatable<Mutation>
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
        public Category category { get; set; }

        public bool Equals([AllowNull] Mutation other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Date.Equals(other.Date) && Name.Equals(other.Name) && Description.Equals(other.Description);
        }

        public override int GetHashCode() => HashCode.Combine(Date, Name, Description);
    }
}
