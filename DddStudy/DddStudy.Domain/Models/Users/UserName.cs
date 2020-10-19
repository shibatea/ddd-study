using System;
using System.Collections.Generic;
using DddStudy.Domain.Core.Models;

namespace DddStudy.Domain.Models.Users
{
    public class UserName : ValueObject<UserName>
    {
        public UserName(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.Length < 3) throw new ArgumentException("ユーザー名は３文字以上です", nameof(value));
            if (value.Length > 20) throw new ArgumentException("ユーザー名は２０文字未満です", nameof(value));

            Value = value;
        }

        public string Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}