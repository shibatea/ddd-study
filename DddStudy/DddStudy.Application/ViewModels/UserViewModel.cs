using DddStudy.Domain.Models;
using DddStudy.Domain.Models.Users;

namespace DddStudy.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(User user)
        {
            Id = user.Id.Value;
            Name = user.Name.Value;
        }

        public string Id { get; }
        public string Name { get; }
    }
}