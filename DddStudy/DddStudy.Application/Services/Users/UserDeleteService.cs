using System;
using DddStudy.Domain.Commands;
using DddStudy.Domain.Interfaces;
using DddStudy.Domain.Models;

namespace DddStudy.Application.Services.Users
{
    public interface IUserDeleteService
    {
        void Handle(UserDeleteCommand command);
    }

    public class UserDeleteService : IUserDeleteService
    {
        private readonly IUserRepository _userRepository;

        public UserDeleteService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Handle(UserDeleteCommand command)
        {
            var targetId = new UserId(command.Id);
            var user = _userRepository.Find(targetId);

            if (user == null)
                // TODO: 削除対象が既にいないので例外を送出しないという判断もあり
                // return;
                // throw new UserNotFoundException(targetId);
                throw new Exception();

            _userRepository.Delete(user);
        }
    }
}