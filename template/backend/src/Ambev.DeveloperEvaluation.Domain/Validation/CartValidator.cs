using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class CartValidator : AbstractValidator<Cart>
{
    public CartValidator()
    {
        // UserId validation
        RuleFor(Cart => Cart.UserId)
            .GreaterThan(0).WithMessage("UserId must be greater than zero.");

        // Date validation
        RuleFor(Cart => Cart.Date)
            .NotEmpty().WithMessage("Date must not be empty.")
            .Matches(@"^\d{4}-\d{2}-\d{2}$")
            .WithMessage("Date must be in the format YYYY-MM-DD.");

        // Products validation
        RuleFor(Cart => Cart.Products)
            .NotEmpty().WithMessage("Cart must contain at least one product.");

        RuleForEach(Cart => Cart.Products).ChildRules(product =>
        {
            product.RuleFor(p => p.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than zero.");

            product.RuleFor(p => p.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
        });

    }
}

