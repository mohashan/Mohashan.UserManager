using FluentValidation.Results;

namespace Mohashan.UserManager.Application.Exceptions;

public class ValidationException : Exception
{
    public List<string> ValidationErrors { get; set; } = new List<string>();

    public ValidationException(ValidationResult validationResult)
    {
        foreach (var item in validationResult.Errors)
        {
            ValidationErrors.Add(item.ErrorMessage);
        }
    }
}