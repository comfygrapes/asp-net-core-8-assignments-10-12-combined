using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WebApplication1.CustomValidators
{
    public class DateRangeValidator : ValidationAttribute
    {
        public string OtherProperty { get; set; }

        public DateRangeValidator(string otherProperty)
        {
            OtherProperty = otherProperty;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherProperty);
            if (value != null && otherProperty != null)
            {
                var removalDate = Convert.ToDateTime(value);
                var entryDate = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));

                if (removalDate > entryDate)
                {
                    return new ValidationResult(ErrorMessage, new string[] {OtherProperty, validationContext.MemberName});
                }
                else
                {
                    return ValidationResult.Success;
                }
               
            }
            return null;
        }
    }
}
