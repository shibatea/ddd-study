using System;
using DddStudy.Domain.Models.Users;

namespace DddStudy.Application.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(UserId id)
        {
            Id = id;
        }

        public UserNotFoundException(UserId id, string message) : base(message)
        {
            Id = id;
        }

        public UserId Id { get; }
    }
}