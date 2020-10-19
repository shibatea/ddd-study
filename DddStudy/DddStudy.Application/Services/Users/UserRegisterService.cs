using DddStudy.Domain;
using DddStudy.Domain.Interfaces;
using DddStudy.Domain.Models.Users;

namespace DddStudy.Application.Services.Users
{
    public interface IUserRegisterService
    {
        void Handle(string name);
    }

    public class UserRegisterService : IUserRegisterService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserService _userService;

        public UserRegisterService(IUserRepository userRepository, UserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        public void Handle(string name)
        {
            var user = new User(new UserName(name));

            if (_userService.Exists(user))
            {
                // throw new CanNotRegisterUserException(user, "ユーザーは既に存在しています。");
            }

            _userRepository.Save(user);
        }
    }
}