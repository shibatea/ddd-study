﻿namespace DddStudy.Domain.Commands.Users
{
    public class UserDeleteCommand
    {
        public UserDeleteCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}