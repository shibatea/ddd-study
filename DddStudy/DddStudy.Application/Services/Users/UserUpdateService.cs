using System;
using DddStudy.Domain;
using DddStudy.Domain.Commands;
using DddStudy.Domain.Interfaces;
using DddStudy.Domain.Models;
using DddStudy.Domain.Models.Users;

namespace DddStudy.Application.Services.Users
{
    public interface IUserUpdateService
    {
        void Handle(UserUpdateCommand command);
    }

    public class UserUpdateService : IUserUpdateService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserService _userService;

        public UserUpdateService(IUserRepository userRepository, UserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        public void Handle(UserUpdateCommand command)
        {
            var targetId = new UserId(command.Id);
            var user = _userRepository.Find(targetId);

            if (user == null)
                // throw new UserNotFoundException(targetId);
                throw new Exception();

            var name = command.Name;
            if (name != null)
            {
                var newUserName = new UserName(name);
                user.ChangeName(newUserName);

                if (_userService.Exists(user))
                    //         // throw new CanNotRegisterUserException(user, "ユーザーは既に存在しています。");
                    throw new Exception();
            }

            var mailAddress = command.MailAddress;
            if (mailAddress != null)
            {
                var newMailAddress = new MailAddress(mailAddress);
                user.ChangeMailAddress(newMailAddress);
            }

            _userRepository.Save(user);
        }
    }
}