using System.ComponentModel.DataAnnotations;

namespace WebApplication1.CustomValidators
{
    public class MinimumYearValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

                DateTime date = (DateTime)value;
                if (date.Year >= 2000)
                {
                    return new ValidationResult("Fail");
                }
                else
                {
                    return ValidationResult.Success;
                }
        }
    }
}
