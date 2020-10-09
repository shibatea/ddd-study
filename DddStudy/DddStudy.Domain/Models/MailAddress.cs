using System.Collections.Generic;
using DddStudy.Domain.Core.Models;

namespace DddStudy.Domain.Models
{
    public class MailAddress : ValueObject<MailAddress>
    {
        public MailAddress(string address)
        {
            Address = address;
        }

        public string Address { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Address;
        }
    }
}