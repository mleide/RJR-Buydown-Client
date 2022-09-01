namespace RJR.BusinessRules
{
    public class ValidationRuleResult<T>
    {
        public ValidationRuleResult(IValidationRule<T> rule, bool isValid, string advice)
        {
            Rule = rule;
            IsValid = isValid;
            Advice = advice;
        }

        public IValidationRule<T> Rule { get; }
        public string Advice { get; }
        public bool IsValid { get; }
        
        public static ValidationRuleResult<T> Valid(IValidationRule<T> rule) => new ValidationRuleResult<T>(rule, true, null);
        public static ValidationRuleResult<T> Invalid(IValidationRule<T> rule, string advice) => new ValidationRuleResult<T>(rule, false, advice);
    }
}