using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Common.ValueObjects;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Ambev.DeveloperEvaluation.Domain.Entities;
/// <summary>
/// Represents a product in the system with its details and rating information.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Product : BaseEntity, IProduct
{
    /// <summary>
    /// Gets the product title or name.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets the product description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets the category of the product.
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product image URL.
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product rating (value object).
    /// </summary>
    public Rating Rating { get; set; } = new Rating(0, 0);

    /// <summary>
    /// Gets the date and time when the user was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the unique identifier of the product.
    /// </summary>
    string IProduct.Id => Id.ToString();

    /// <summary>
    /// Initializes a new instance of the Product class.
    /// </summary>
    public Product()
    {
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Performs validation of the product entity using the ProductValidator rules.
    /// </summary>
    public ValidationResultDetail Validate()
    {
        var validator = new ProductValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
