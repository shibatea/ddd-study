using System;
using System.Collections.Generic;
using DddStudy.Domain.Core.Models;
using DddStudy.Domain.Models.Users;

namespace DddStudy.Domain.Models.Circles
{
    public class Circle : ValueObject<Circle>
    {
        public Circle(CircleId id, CircleName name, User owner, List<UserId> members)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            Members = members;
        }

        public CircleId Id { get; }
        public CircleName Name { get; }
        public User Owner { get; }
        public List<UserId> Members { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }

        public void Join(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            if (IsFull()) throw new CircleFullException(Id);

            Members.Add(user.Id);
        }

        private bool IsFull()
        {
            return Members.Count >= 29;
        }
    }
}