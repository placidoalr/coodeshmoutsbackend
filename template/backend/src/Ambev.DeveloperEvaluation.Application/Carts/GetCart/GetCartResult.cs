using Ambev.DeveloperEvaluation.Common.ValueObjects;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Response model for GetCart operation
/// </summary>
public class GetCartResult
{    
    /// <summary>
     /// Gets or sets the unique identifier of the Cart.
     /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Cart title or name.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Cart price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the Cart description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Cart category.
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Cart image URL.
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Cart rating (value object).
    /// </summary>
    public Rating Rating { get; set; } = new Rating(0, 0);
}
