using System.Collections.Generic;
using System.Linq;

namespace RJR.BusinessRules
{
    public class ValidationResult<T>
    {
        public ValidationResult(T target)
        {
            Target = target;
        }

        public ValidationResult(T target, List<ValidationRuleResult<T>> results)
        {
            Target = target;
            RuleResults = results;
        }

        public T Target { get; }
        public bool IsValid => RuleResults.All(p => p.IsValid);
        public List<ValidationRuleResult<T>> RuleResults { get; } =
            new List<ValidationRuleResult<T>>();
    }
}