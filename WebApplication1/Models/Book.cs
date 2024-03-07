using System.ComponentModel.DataAnnotations;
using WebApplication1.CustomValidators;

namespace WebApplication1.Models
{
    public class Book : IValidatableObject
    {
        [Range(0, int.MaxValue)]
        public int? BookId { get; set; }
        public string? Author { get; set; }

        public DateTime? EntryDate { get; set; }
        [DateRangeValidator("EntryDate", ErrorMessage = "Entry Date should be older than 'Remove Date'")]
        public DateTime? RemovalDate { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public int? Age { get; set; }

        public List<string?> Borrowers { get; set; } = new();

        public override string ToString()
        {
            return $"Book object - Book id: {BookId}, Author: {Author}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!DateOfBirth.HasValue && !Age.HasValue)
            {
                yield return new ValidationResult("Either Date of Birth or Age must be supplied", new[] { nameof(Age) });
            }
        }
    }
}
