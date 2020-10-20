namespace DddStudy.Domain.Models.Users
{
    public interface IUserNotification
    {
        void Id(UserId id);
        void Name(UserName name);
    }
}