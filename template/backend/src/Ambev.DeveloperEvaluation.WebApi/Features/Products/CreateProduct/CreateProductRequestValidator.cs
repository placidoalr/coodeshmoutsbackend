using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductRequest that defines validation rules for Product creation.
/// </summary>
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Email: Must be valid format (using EmailValidator)
    /// - Productname: Required, length between 3 and 50 characters
    /// - Password: Must meet security requirements (using PasswordValidator)
    /// - Phone: Must match international format (+X XXXXXXXXXX)
    /// - Status: Cannot be Unknown
    /// - Role: Cannot be None
    /// </remarks>
    public CreateProductRequestValidator()
    {
        // Title validation
        RuleFor(req => req.Title)
            .NotEmpty().WithMessage("Product title must not be empty.")
            .Length(3, 100).WithMessage("Product title must be between 3 and 100 characters.");

        // Price validation
        RuleFor(req => req.Price)
            .GreaterThan(0).WithMessage("Product price must be greater than zero.");

        // Description validation
        RuleFor(req => req.Description)
            .NotEmpty().WithMessage("Product description must not be empty.")
            .MaximumLength(500).WithMessage("Product description cannot exceed 500 characters.");

        // Category validation
        RuleFor(req => req.Category)
            .NotEmpty().WithMessage("Product category must not be empty.")
            .MaximumLength(50).WithMessage("Product category cannot exceed 50 characters.");

        // Image validation
        RuleFor(req => req.Image)
            .NotEmpty().WithMessage("Product image URL must not be empty.")
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
            .WithMessage("Product image must be a valid URL.");

        // Rating validation
        RuleFor(req => req.Rating)
            .NotNull().WithMessage("Product rating must not be null.");

        RuleFor(req => req.Rating.Rate)
            .InclusiveBetween(0, 5).WithMessage("Product rating must be between 0 and 5.");

        RuleFor(req => req.Rating.Count)
            .GreaterThanOrEqualTo(0).WithMessage("Product rating count must be zero or greater.");
    }
}