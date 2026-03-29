using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        // Title validation
        RuleFor(product => product.Title)
            .NotEmpty().WithMessage("Product title must not be empty.")
            .MinimumLength(3).WithMessage("Product title must be at least 3 characters long.")
            .MaximumLength(100).WithMessage("Product title cannot be longer than 100 characters.");

        // Price validation
        RuleFor(product => product.Price)
            .GreaterThan(0).WithMessage("Product price must be greater than zero.");

        // Description validation
        RuleFor(product => product.Description)
            .NotEmpty().WithMessage("Product description must not be empty.")
            .MaximumLength(500).WithMessage("Product description cannot exceed 500 characters.");

        // Category validation
        RuleFor(product => product.Category)
            .NotEmpty().WithMessage("Product category must not be empty.")
            .MaximumLength(50).WithMessage("Product category cannot exceed 50 characters.");

        // Image validation
        RuleFor(product => product.Image)
            .NotEmpty().WithMessage("Product image URL must not be empty.")
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
            .WithMessage("Product image must be a valid URL.");

        // Rating validation
        RuleFor(product => product.Rating)
            .NotNull().WithMessage("Product rating must not be null.");

        RuleFor(product => product.Rating.Rate)
            .InclusiveBetween(0, 5).WithMessage("Product rating must be between 0 and 5.");

        RuleFor(product => product.Rating.Count)
            .GreaterThanOrEqualTo(0).WithMessage("Product rating count must be zero or greater.");
    }
}

