using DddStudy.Application.ViewModels;
using DddStudy.Domain.Interfaces;
using DddStudy.Domain.Models;
using DddStudy.Domain.Models.Users;

namespace DddStudy.Application.Services.Users
{
    public interface IGetUserInfoService
    {
        UserViewModel Handle(string userId);
    }

    public class GetUserInfoService : IGetUserInfoService
    {
        private readonly IUserRepository _userRepository;

        public GetUserInfoService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserViewModel Handle(string userId)
        {
            var targetId = new UserId(userId);
            var user = _userRepository.Find(targetId);

            return user == null ? null : new UserViewModel(user);
        }
    }
}