using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Order : IValidatableObject
    {
        public int? OrderNo { get; set; }

        [Required(ErrorMessage = "{0} can't be blank.")]
        [Display(Name = "Order Date")]
        public DateTime? OrderDate { get; set; }

        [Required]
        [Display(Name = "Invoice Price")]
        public double? InvoicePrice { get; set; }

        [Required]
        public List<Product?> Products { get; set; } = new();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var totalCost = Products?.Sum(p => p?.Price * p?.Quantity);
            if (InvoicePrice != totalCost)
            {
                yield return new ValidationResult($"{nameof(InvoicePrice)} should be equal to the total cost of all products (i.e. {totalCost}) in the order.", new[] { nameof(InvoicePrice) });
            }
            var minDate = Convert.ToDateTime("2000-01-01");
            if (OrderDate <= minDate)
            {
                yield return new ValidationResult($"{nameof(OrderDate)} must be greater or equal to '2000-01-01'");
            }
        }
    }
}
