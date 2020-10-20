using DddStudy.Domain.Interfaces;
using DddStudy.Domain.Models.Circles;

namespace DddStudy.Domain.Models.CircleMembers
{
    public class CircleRecommendSpecification : ISpecification<Circle>
    {
        public bool IsSatisfiedBy(Circle value)
        {
            return true;
        }
    }
}