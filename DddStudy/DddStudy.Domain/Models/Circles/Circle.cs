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
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (owner == null) throw new ArgumentNullException(nameof(owner));
            if (members == null) throw new ArgumentNullException(nameof(members));

            Id = id;
            Name = name;
            Owner = owner;
            _members = members;
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

            if (_members.Count >= 29)
            {
                throw new CircleFullException(Id);
            }

            _members.Add(member);
        }
    }
}