using DddStudy.Domain.Interfaces;
using System.Linq;

namespace DddStudy.Domain.Models.Circles
{
    public class CircleFullSpecification
    {
        private readonly IUserRepository _userRepository;

        public CircleFullSpecification(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsSatisfiedBy(Circle circle)
        {
            // UserRepository から所属メンバー情報を取得
            var users = _userRepository.Find(circle.Members);

            // プレミアム会員メンバーを抽出
            var premiumUserNumber = users.Count(user => user.IsPremium);

            // サークルメンバーの上限値を算出
            var circleUpperLimit = premiumUserNumber < 10 ? 30 : 50;

            // 現在のサークルメンバー数が上限に達しているか判定する
            return circle.CountMembers() >= circleUpperLimit;
        }
    }
}