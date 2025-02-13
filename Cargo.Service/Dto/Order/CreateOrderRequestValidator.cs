using FluentValidation;

namespace Cargo.Service.Dto.Order;

public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderRequestValidator()
    {
        RuleFor(x => x.OrderDesi)
            .GreaterThan(0);
    }
}