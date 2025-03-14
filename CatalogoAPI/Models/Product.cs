using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CatalogoAPI.Validators;

namespace CatalogoAPI.Models;

public class Product : IValidatableObject
{
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    // [FirstLetterUpperCase]
    public string? Name { get; set; }

    [Required]
    [StringLength(300)]
    public string? Description { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal price { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImageUrl { get; set; }
    public float Stock { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!string.IsNullOrEmpty(Name))
        {
            var firstLetter = Name[0].ToString();
            if (firstLetter != firstLetter.ToUpper())
            {
                yield return new ValidationResult("First letter must be uppercase", [nameof(Name)]);
            }
        }

        if (Stock <= 0)
        {
            yield return new ValidationResult("Stock has to be greater than 0", [nameof(Stock)]);
        }
    }
}
