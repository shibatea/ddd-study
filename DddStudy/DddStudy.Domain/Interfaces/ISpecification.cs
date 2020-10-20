namespace DddStudy.Domain.Interfaces
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T value);
    }
}