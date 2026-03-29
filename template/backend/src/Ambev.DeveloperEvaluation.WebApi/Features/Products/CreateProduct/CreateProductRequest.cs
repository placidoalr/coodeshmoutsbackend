using Ambev.DeveloperEvaluation.Common.ValueObjects;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Represents a request to create a new Product in the system.
/// </summary>
public class CreateProductRequest
{    /// <summary>
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

}