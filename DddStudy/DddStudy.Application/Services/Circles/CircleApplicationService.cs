using System.Transactions;
using DddStudy.Application.Exceptions;
using DddStudy.Domain;
using DddStudy.Domain.Commands.Circles;
using DddStudy.Domain.Interfaces;
using DddStudy.Domain.Models.Circles;
using DddStudy.Domain.Models.Users;

namespace DddStudy.Application.Services.Circles
{
    public class CircleApplicationService
    {
        private readonly ICircleFactory _circleFactory;
        private readonly ICircleRepository _circleRepository;
        private readonly CircleService _circleService;
        private readonly IUserRepository _userRepository;

        public CircleApplicationService(
            ICircleFactory circleFactory,
            ICircleRepository circleRepository,
            CircleService circleService,
            IUserRepository userRepository)
        {
            _circleFactory = circleFactory;
            _circleRepository = circleRepository;
            _circleService = circleService;
            _userRepository = userRepository;
        }

        public void Create(CircleCreateCommand command)
        {
            using var transaction = new TransactionScope();

            var ownerId = new UserId(command.UserId);
            var owner = _userRepository.Find(ownerId);
            if (owner == null) throw new UserNotFoundException(ownerId, "サークルのオーナーとなるユーザーが見つかりませんでした。");

            var name = new CircleName(command.Name);
            var circle = _circleFactory.Create(name, owner);
            if (_circleService.Exists(circle)) throw new CanNotRegisterCircleException(circle, "サークルは既に存在しています。");

            _circleRepository.Save(circle);

            transaction.Complete();
        }

        public void Join(CircleJoinCommand command)
        {
            using var transaction = new TransactionScope();

            var circleId = new CircleId(command.CircleId);
            var circle = _circleRepository.Find(circleId);
            if (circle == null)
            {
                throw new CircleNotFoundException(circleId, "サークルが見つかりませんでした。");
            }

            var circleFullSpecification = new CircleFullSpecification(_userRepository);
            if (circleFullSpecification.IsSatisfiedBy(circle))
            {
                throw new CircleFullException(circle.Id);
            }

            var memberId = new UserId(command.UserId);
            var member = _userRepository.Find(memberId);
            if (member == null)
            {
                throw new UserNotFoundException(memberId, "ユーザーが見つかりませんでした。");
            }

            circle.Join(member);
            _circleRepository.Save(circle);

            transaction.Complete();
        }
    }
}