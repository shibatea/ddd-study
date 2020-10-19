using System;
using DddStudy.Domain.Models.Circles;

namespace DddStudy.Application.Exceptions
{
    public class CanNotRegisterCircleException : Exception
    {
        public CanNotRegisterCircleException(Circle circle)
        {
            Circle = circle;
        }

        public CanNotRegisterCircleException(Circle circle, string message) : base(message)
        {
            Circle = circle;
        }

        public Circle Circle { get; }
    }
}