using System.Collections.Generic;
using DddStudy.Domain.Models.Users;

namespace DddStudy.Domain.Interfaces
{
    public interface IUserRepository
    {
        User Find(UserId id);
        User Find(UserName name);
        void Save(User user);
        void Delete(User user);
        List<User> Find(List<UserId> circleMembers);
    }
}