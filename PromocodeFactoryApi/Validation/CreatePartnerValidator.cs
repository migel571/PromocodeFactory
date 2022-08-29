using FluentValidation;
using PromocodeFactory.Api.Commands;

namespace PromocodeFactory.Api.Validation
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
