using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Common.ValueObjects;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Command to create a new Product.
/// Encapsulates the data required to create a product in the system.
/// </summary>
public class CreateProductCommand : IRequest<CreateProductResult>
{
    /// <summary>
    /// Gets or sets the product title or name.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the product price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the product description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the product category.
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the product image URL.
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the product rating (value object).
    /// </summary>
    public Rating Rating { get; set; } = new Rating(0, 0);

    /// <summary>
    /// Performs validation of the product creation command using the CreateProductCommandValidator rules.
    /// </summary>
    public ValidationResultDetail Validate()
    {
        var validator = new CreateProductCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
