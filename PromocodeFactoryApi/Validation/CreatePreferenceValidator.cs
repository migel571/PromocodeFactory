using FluentValidation;
using PromocodeFactoryApi.Commands;

namespace PromocodeFactoryApi.Validation
{
    public class CreatePreferenceValidator : AbstractValidator<CreatePreferenceCommand>
    {
        public CreatePreferenceValidator()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty();
        }
    }
}
