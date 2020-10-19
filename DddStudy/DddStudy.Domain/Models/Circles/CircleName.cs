using System;
using System.Collections.Generic;
using DddStudy.Domain.Core.Models;

namespace DddStudy.Domain.Models.Circles
{
    public class CircleName : ValueObject<CircleName>
    {
        public CircleName(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.Length < 3) throw new ArgumentException("サークル名は3文字以上です。", nameof(value));
            if (value.Length < 20) throw new ArgumentException("サークル名は20文字以下です。", nameof(value));

            Value = value;
        }

        public string Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}