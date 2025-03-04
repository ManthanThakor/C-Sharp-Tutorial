using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.CustomValidation
{
    public class DateGreaterThanOrEqualAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateGreaterThanOrEqualAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
            if (property == null)
                return new ValidationResult($"Unknown property: {_comparisonProperty}");

            var comparisonValue = (DateTime)property.GetValue(validationContext.ObjectInstance);
            var currentValue = (DateTime)value;

            return currentValue >= comparisonValue
                ? ValidationResult.Success
                : new ValidationResult(ErrorMessage ?? "End date must be greater than or equal to the start date.");
        }
    }
}
