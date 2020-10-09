﻿using DddStudy.Domain.Models;

namespace DddStudy.Domain.Interfaces
{
    public interface IUserRepository
    {
        User Find(UserId id);
        User Find(UserName name);
        void Save(User user);
        void Delete(User user);
    }
}