using Ambev.DeveloperEvaluation.Common.ValueObjects;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

/// <summary>
/// Represents a request to create a new Cart in the system.
/// </summary>
public class CreateCartRequest
{
    /// <summary>
    /// Gets or sets the user identifier associated with the Cart.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Gets or sets the Cart creation date (string format YYYY-MM-DD).
    /// </summary>
    public string Date { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the list of products in the Cart.
    /// </summary>
    public IEnumerable<CartProduct> Products { get; set; } = new List<CartProduct>();
}
