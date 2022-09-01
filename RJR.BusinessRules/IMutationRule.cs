namespace RJR.BusinessRules
{
    public interface IMutationRule<T> : IRule<T>
    {
        void Mutate(T obj);
    }
}