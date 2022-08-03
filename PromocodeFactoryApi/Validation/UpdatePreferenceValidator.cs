using FluentValidation;
using PromocodeFactoryApi.Commands;

namespace PromocodeFactoryApi.Validation
{
    public class UpdatePreferenceValidator : AbstractValidator<UpdatePreferenceCommand>
    {
        public UpdatePreferenceValidator()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty();
        }
    }
}
