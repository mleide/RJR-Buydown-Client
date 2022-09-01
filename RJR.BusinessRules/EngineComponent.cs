using System;
using System.Collections.Generic;

namespace RJR.BusinessRules
{
    class EngineComponent<T>
    {
        readonly List<IMutationRule<T>> _mutationRules = new List<IMutationRule<T>>();
        readonly List<IValidationRule<T>> _validationRules = new List<IValidationRule<T>>();

        public bool ThrowOnFailedValidation { get; set; }

        public void Register(IMutationRule<T> rule)
        {
            _mutationRules.Add(rule);
        }

        public void Register(IValidationRule<T> rule)
        {
            _validationRules.Add(rule);
        }

        public void Mutate(IEnumerable<T> objs)
        {
            foreach (var obj in objs)
                Mutate(obj);
        }

        public void Mutate(T obj)
        {
            foreach (var rule in _mutationRules)
                rule.Mutate(obj);
        }

        public List<ValidationResult<T>> Validate(IEnumerable<T> objs)
        {
            var results = new List<ValidationResult<T>>();
            foreach (var obj in objs)
            {
                results.Add(
                    new ValidationResult<T>(
                        obj, 
                        Validate(obj)));
            }
            return results;
        }

        public List<ValidationRuleResult<T>> Validate(T obj)
        {
            var results = new List<ValidationRuleResult<T>>();
            foreach (var rule in _validationRules)
            {
                var result = rule.Validate(obj);
                results.Add(result);

                if (!result.IsValid)
                {
                    Console.WriteLine($"A {typeof(T).Name} failed to validate:");
                    Console.WriteLine(result.Advice);
                    if (ThrowOnFailedValidation)
                        throw new Exception(result.Advice);
                }
            }

            return results;
        }
    }
}