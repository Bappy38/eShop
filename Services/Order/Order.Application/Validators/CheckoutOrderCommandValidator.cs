using FluentValidation;
using Order.Application.Commands;

namespace Order.Application.Validators;

public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
{
    public CheckoutOrderCommandValidator()
    {
        RuleFor(o => o.UserName)
            .NotNull()
            .NotEmpty()
            .WithMessage("{UserName} is required")
            .MaximumLength(50)
            .WithMessage("{UserName} must not exceed 50 characters");

        RuleFor(o => o.TotalPrice)
            .NotNull()
            .NotEmpty()
            .WithMessage("{TotalPrice} is required")
            .GreaterThan(-1)
            .WithMessage("{TotalPrice} should not be -ve");

        RuleFor(o => o.EmailAddress)
            .NotNull()
            .NotEmpty()
            .WithMessage("{EmailAddress} is required")
            .EmailAddress()
            .WithMessage("{EmailAddress} is not valid");
    }
}
