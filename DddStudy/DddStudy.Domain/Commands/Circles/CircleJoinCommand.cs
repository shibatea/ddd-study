namespace DddStudy.Domain.Commands.Circles
{
    public class CircleJoinCommand
    {
        public CircleJoinCommand(string userId, string circleId)
        {
            UserId = userId;
            CircleId = circleId;
        }

        public string UserId { get; }
        public string CircleId { get; }
    }
}