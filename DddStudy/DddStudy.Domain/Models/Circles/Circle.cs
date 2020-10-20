using System;
using System.Collections.Generic;
using DddStudy.Domain.Core.Models;
using DddStudy.Domain.Models.Users;

namespace DddStudy.Domain.Models.Circles
{
    public class Circle : ValueObject<Circle>
    {
        private readonly List<User> _members;

        public Circle(CircleId id, CircleName name, User owner, List<User> members)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            _members = members ?? throw new ArgumentNullException(nameof(members));
        }

        public CircleId Id { get; }
        public CircleName Name { get; }
        public User Owner { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }

        public void Join(User member)
        {
            if (member == null) throw new ArgumentNullException(nameof(member));

            if (IsFull()) throw new CircleFullException(Id);

            _members.Add(member);
        }

        private bool IsFull()
        {
            return _members.Count >= 29;
        }
    }
}