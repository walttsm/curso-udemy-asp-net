using System.ComponentModel.DataAnnotations;

namespace CatalogoAPI.Validators;

public class FirstLetterUpperCase : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {

        var stringValue = value?.ToString() ?? string.Empty;

        if (string.IsNullOrEmpty(stringValue.ToString()))
        {
            return ValidationResult.Success!;
        }

        var firstLetter = stringValue.ToString()[0].ToString();

        if (firstLetter != firstLetter.ToUpper())
        {
            return new ValidationResult("First letter must be uppercase");
        }

        return ValidationResult.Success!;
    }
}
