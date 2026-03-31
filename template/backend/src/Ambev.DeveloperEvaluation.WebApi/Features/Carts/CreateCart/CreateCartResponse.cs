using Ambev.DeveloperEvaluation.Common.ValueObjects;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
/// <summary>
/// Represents the response returned after creating a new Cart.
/// Encapsulates the Cart data that was successfully created.
/// </summary>
public class CreateCartResponse
{
    /// <summary>
    /// Gets or sets the unique identifier of the Cart.
    /// </summary>
    public int Id { get; set; }

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
