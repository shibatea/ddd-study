using System;
using DddStudy.Domain.Models.Circles;

namespace DddStudy.Application.Exceptions
{
    public class CircleNotFoundException : Exception
    {
        public CircleNotFoundException(CircleId id)
        {
            Id = id;
        }

        public CircleNotFoundException(CircleId id, string message) : base(message)
        {
            Id = id;
        }

        public CircleId Id { get; }
    }
}