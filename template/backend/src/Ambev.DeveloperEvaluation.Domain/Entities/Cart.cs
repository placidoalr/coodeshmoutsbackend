using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Common.ValueObjects;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Ambev.DeveloperEvaluation.Domain.Entities;
/// <summary>
/// Represents a Cart in the system with its details and rating information.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Cart : BaseEntity, ICart
{

    /// <summary>
    /// Gets or sets the user identifier who owns the Cart.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Gets or sets the date when the Cart was created.
    /// </summary>
    public string Date { get; set; }

    /// <summary>
    /// Gets or sets the collection of products in the Cart.
    /// </summary>
    public IEnumerable<CartProduct> Products { get; set; } = new List<CartProduct>();
    public Cart(int userId, string date, IEnumerable<CartProduct> products)
    {
        UserId = userId;
        Date = date;
        Products = products;
    }

    // Construtor vazio para EF Core
    protected Cart() { }

    /// <summary>
    /// Performs validation of the Cart entity using the CartValidator rules.
    /// </summary>
    public ValidationResultDetail Validate()
    {
        var validator = new CartValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
