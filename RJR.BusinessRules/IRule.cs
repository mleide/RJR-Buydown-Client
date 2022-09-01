namespace RJR.BusinessRules
{
    public interface IRule<T>
    {
        RuleType RuleType { get; }
        string Name { get; }
        string Description { get; }
    }
}