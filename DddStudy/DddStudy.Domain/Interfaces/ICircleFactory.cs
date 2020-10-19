using DddStudy.Domain.Models.Circles;
using DddStudy.Domain.Models.Users;

namespace DddStudy.Domain.Interfaces
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}