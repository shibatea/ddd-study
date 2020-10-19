using System;
using DddStudy.Domain.Models.Circles;

namespace DddStudy.Application.Exceptions
{
    public class CircleFullException : Exception
    {
        public CircleFullException(CircleId id)
        {
            Id = id;
        }

        public CircleFullException(CircleId id, string message) : base(message)
        {
            Id = id;
        }

        public CircleId Id { get; }
    }
}