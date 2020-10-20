using DddStudy.Domain.Models.Users;

namespace DddStudy.Domain.Interfaces
{
    public interface IUserNotification
    {
        void Id(UserId id);
        void Name(UserName name);
    }
}