using System.Collections.Generic;
using System.Linq;
using DddStudy.Domain.Models.Circles;
using DddStudy.Domain.Models.Users;

namespace DddStudy.Domain.Models.CircleMembers
{
    public class CircleMembers
    {
        private readonly List<User> _members;
        private readonly User _owner;

        public CircleMembers(CircleId id, User owner, List<User> members)
        {
            Id = id;
            _owner = owner;
            _members = members;
        }

        public CircleId Id { get; }

        public int CountMembers()
        {
            return _members.Count + 1;
        }

        public int CountPremiumMembers(bool containsOwner = true)
        {
            var premiumUserNumber = _members.Count(member => member.IsPremium);
            return containsOwner
                ? premiumUserNumber + (_owner.IsPremium ? 1 : 0)
                : premiumUserNumber;
        }
    }
}