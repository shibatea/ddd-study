using System;
using System.Collections.Generic;
using DddStudy.Domain.Core.Models;

namespace DddStudy.Domain.Models.Users
{
    public class User : ValueObject<User>
    {
        public User(UserName name)
        {
            if (Name == null) throw new ArgumentNullException(nameof(name));

            Id = new UserId(Guid.NewGuid().ToString("D"));
            Name = name;
        }

        public User(UserId id, UserName name)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public UserId Id { get; }
        public UserName Name { get; private set; }
        public MailAddress MailAddress { get; set; }

        public void ChangeName(UserName name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void ChangeMailAddress(MailAddress mailAddress)
        {
            MailAddress = mailAddress ?? throw new ArgumentNullException(nameof(mailAddress));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // エンティティなので UserId のみで識別する
            yield return Id;
        }
    }
}