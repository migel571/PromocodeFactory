using FluentValidation;
using PromocodeFactoryApi.Commands;

namespace PromocodeFactoryApi.Validation
{
    public class CreatePromoCodeValidator : AbstractValidator<CreatePromoCodeCommand>
    {
        public CreatePromoCodeValidator()
        {
            RuleFor(r => r.Code).NotEmpty().NotNull();
            RuleFor(r => r.BeginDate).Cascade(CascadeMode.Stop).NotEmpty().Must(date=>date!=default(DateTime)).NotNull();
            RuleFor(r => r.EndDate).NotEmpty().Must(date => date != default(DateTime)).NotNull();
            RuleFor(r=>r.ServiceInfo).NotEmpty().NotNull();
            RuleFor(r=>r.PartnerName).NotEmpty().NotNull();
        }
    }
}
