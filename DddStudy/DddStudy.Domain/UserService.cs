using DddStudy.Domain.Interfaces;
using DddStudy.Domain.Models;
using DddStudy.Domain.Models.Users;

namespace DddStudy.Domain
{
    /// <summary>
    /// Userドメインサービス
    /// UserDomainモデルにあると不自然な振る舞いをこのサービスに定義する
    /// </summary>
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