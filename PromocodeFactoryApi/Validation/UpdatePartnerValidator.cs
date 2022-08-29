using FluentValidation;
using PromocodeFactory.Api.Commands;

namespace PromocodeFactory.Api.Validation
{
    public class UpdatePartnerValidator : AbstractValidator<CreatePartnerCommand>
    {
        public UpdatePartnerValidator()
        {
            RuleFor(r => r.Name).NotEmpty().NotNull();
            RuleFor(r => r.IsActive).NotEmpty().NotNull();
            RuleFor(r => r.NumberIssuedPromoCode).NotEmpty().NotNull();
        }
    }
}
