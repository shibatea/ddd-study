using DddStudy.Domain.Interfaces;
using DddStudy.Domain.Models.Circles;

namespace DddStudy.Domain
{
    public class CircleService
    {
        private readonly ICircleRepository _repository;

        public CircleService(ICircleRepository repository)
        {
            _repository = repository;
        }

        public bool Exists(Circle circle)
        {
            var duplicated = _repository.Find(circle.Name);
            return duplicated != null;
        }
    }
}