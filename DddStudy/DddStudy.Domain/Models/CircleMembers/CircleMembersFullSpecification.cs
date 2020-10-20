namespace DddStudy.Domain.Models.CircleMembers
{
    public class CircleMembersFullSpecification
    {
        public bool IsSatisfiedBy(CircleMembers members)
        {
            var premiumNumber = members.CountPremiumMembers(false);
            var circleUpperLimit = premiumNumber < 10 ? 30 : 50;
            return members.CountMembers() >= circleUpperLimit;
        }
    }
}