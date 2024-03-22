using Core.Secure.Business.Domain.AggregatesModel.CartAggregate;
using FluentValidation;

namespace Core.Secure.Business.Domain.Validations.CartValidation;

public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
{
    public CreateCartRequestValidator()
    {
        RuleFor(m => m.DealerId).NotNull().NotEmpty()
            .WithMessage($"{nameof(CreateCartRequest.DealerId)} is required.");

        RuleFor(m => m.ProductId).NotNull().NotEmpty()
            .WithMessage($"{nameof(CreateCartRequest.ProductId)} is required.");
        
        RuleFor(m => m.UnitId).NotNull().NotEmpty()
            .WithMessage($"{nameof(CreateCartRequest.UnitId)} is required.");
        
        RuleFor(m => m.Quantity).NotNull().NotEmpty()
            .WithMessage($"{nameof(CreateCartRequest.Quantity)} is required.");
    }
}