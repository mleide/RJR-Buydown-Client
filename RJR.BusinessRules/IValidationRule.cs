namespace RJR.BusinessRules
{
    public interface IValidationRule<T> : IRule<T>
    {
        ValidationRuleResult<T> Validate(T obj);
    }
}