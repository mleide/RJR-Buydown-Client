using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using RJR.Core;

namespace RJR.BusinessRules
{
    public class Engine
    {
        readonly EngineComponent<Packing> _packingComponent = new EngineComponent<Packing>();
        readonly EngineComponent<Product> _productComponent = new EngineComponent<Product>();
        readonly EngineComponent<Outlet> _outletComponent = new EngineComponent<Outlet>();
        readonly EngineComponent<DiscountRate> _discountRateComponent = new EngineComponent<DiscountRate>();

        bool _throwOnFailedValidation;

        public bool ThrowOnFailedValidation
        {
            get => _throwOnFailedValidation;
            set
            {
                _throwOnFailedValidation = value;
                _packingComponent.ThrowOnFailedValidation = _throwOnFailedValidation;
                _productComponent.ThrowOnFailedValidation = _throwOnFailedValidation;
                _outletComponent.ThrowOnFailedValidation = _throwOnFailedValidation;
                _discountRateComponent.ThrowOnFailedValidation = _throwOnFailedValidation;
            }
        }

        public void RegisterRule(IMutationRule<Packing> rule) =>
            _packingComponent.Register(rule);

        public void RegisterRule(IValidationRule<Packing> rule) =>
            _packingComponent.Register(rule);

        public void RegisterRule(IMutationRule<Product> rule) =>
            _productComponent.Register(rule);

        public void RegisterRule(IValidationRule<Product> rule) =>
            _productComponent.Register(rule);

        public void RegisterRule(IMutationRule<Outlet> rule) =>
            _outletComponent.Register(rule);

        public void RegisterRule(IValidationRule<Outlet> rule) =>
            _outletComponent.Register(rule);

        public void RegisterRule(IMutationRule<DiscountRate> rule) =>
            _discountRateComponent.Register(rule);

        public void RegisterRule(IValidationRule<DiscountRate> rule) =>
            _discountRateComponent.Register(rule);

        

        public void Mutate(params Product[] products) => _productComponent.Mutate(products);
        public List<ValidationResult<Product>> Validate(params Product[] products) => _productComponent.Validate(products);

        public void Mutate(params Packing[] packing) => _packingComponent.Mutate(packing);
        public List<ValidationResult<Packing>> Validate(params Packing[] packings) => _packingComponent.Validate(packings);

        public void Mutate(params Outlet[] outlets) => _outletComponent.Mutate(outlets);
        public List<ValidationResult<Outlet>> Validate(params Outlet[] outlets) => _outletComponent.Validate(outlets);

        public void Mutate(params DiscountRate[] discountRates) => _discountRateComponent.Mutate(discountRates);
        public List<ValidationResult<DiscountRate>> Validate(params DiscountRate[] discountRates) => _discountRateComponent.Validate(discountRates);
    }
}
