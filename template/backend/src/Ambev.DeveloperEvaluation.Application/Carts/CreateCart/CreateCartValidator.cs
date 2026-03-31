using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Validator for CreateCartCommand that defines validation rules for Cart creation command.
/// </summary>
public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateCartCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Email: Must be in valid format (using EmailValidator)
    /// - Cartname: Required, must be between 3 and 50 characters
    /// - Password: Must meet security requirements (using PasswordValidator)
    /// - Phone: Must match international format (+X XXXXXXXXXX)
    /// - Status: Cannot be set to Unknown
    /// - Role: Cannot be set to None
    /// </remarks>
    public CreateCartCommandValidator()
    {
        // Title validation
        RuleFor(Cart => Cart.Title)
            .NotEmpty().WithMessage("Cart title must not be empty.")
            .Length(3, 100).WithMessage("Cart title must be between 3 and 100 characters.");

        // Price validation
        RuleFor(Cart => Cart.Price)
            .GreaterThan(0).WithMessage("Cart price must be greater than zero.");

        // Description validation
        RuleFor(Cart => Cart.Description)
            .NotEmpty().WithMessage("Cart description must not be empty.")
            .MaximumLength(500).WithMessage("Cart description cannot exceed 500 characters.");

        // Category validation
        RuleFor(Cart => Cart.Category)
            .NotEmpty().WithMessage("Cart category must not be empty.")
            .MaximumLength(50).WithMessage("Cart category cannot exceed 50 characters.");

        // Image validation
        RuleFor(Cart => Cart.Image)
            .NotEmpty().WithMessage("Cart image URL must not be empty.")
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
            .WithMessage("Cart image must be a valid URL.");

        // Rating validation
        RuleFor(Cart => Cart.Rating)
            .NotNull().WithMessage("Cart rating must not be null.");

        RuleFor(Cart => Cart.Rating.Rate)
            .InclusiveBetween(0, 5).WithMessage("Cart rating must be between 0 and 5.");

        RuleFor(Cart => Cart.Rating.Count)
            .GreaterThanOrEqualTo(0).WithMessage("Cart rating count must be zero or greater.");
    }

}