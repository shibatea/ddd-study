using DddStudy.Domain.Interfaces;
using DddStudy.Domain.Models;

namespace DddStudy.Domain
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Exists(User user)
        {
            var duplicatedUser = _userRepository.Find(user.Name);

            return duplicatedUser != null;
        }
    }
}