using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
/// <summary>
/// Provides validation rules for the CreateCartRequest.
/// Ensures that Cart request data meets domain requirements before being converted into a command.
/// </summary>
public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
{
    public CreateCartRequestValidator()
    {
        // UserId validation
        RuleFor(req => req.UserId)
            .GreaterThan(0).WithMessage("UserId must be greater than zero.");

        // Date validation
        RuleFor(req => req.Date)
            .NotEmpty().WithMessage("Date must not be empty.")
            .Matches(@"^\d{4}-\d{2}-\d{2}$")
            .WithMessage("Date must be in the format YYYY-MM-DD.");

        // Products validation
        RuleFor(req => req.Products)
            .NotEmpty().WithMessage("Cart must contain at least one product.");

        RuleForEach(req => req.Products).ChildRules(product =>
        {
            product.RuleFor(p => p.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than zero.");

            product.RuleFor(p => p.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
        });
    }

}