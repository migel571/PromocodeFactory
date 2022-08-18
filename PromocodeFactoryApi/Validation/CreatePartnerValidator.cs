using FluentValidation;
using PromocodeFactoryApi.Commands;

namespace PromocodeFactoryApi.Validation
{
    public class CreatePartnerValidator: AbstractValidator<CreatePartnerCommand>
    {
        public CreatePartnerValidator()
        {
            RuleFor(r => r.Name).NotEmpty().NotNull();
            RuleFor(r => r.IsActive).NotEmpty().NotNull();
            RuleFor(r => r.NumberIssuedPromoCode).NotEmpty().NotNull();
        }
    }
}
