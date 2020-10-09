using System;
using System.Collections.Generic;
using DddStudy.Domain.Core.Models;

namespace DddStudy.Domain.Models
{
    public class UserId : ValueObject<UserId>
    {
        public UserId(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}