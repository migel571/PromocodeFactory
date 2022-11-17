using FluentValidation;
using PromocodeFactory.Api.Commands;

namespace PromocodeFactory.Api.Validation
{
    public class CreatePreferenceValidator : AbstractValidator<CreatePreferenceCommand>
    {
        public CreatePreferenceValidator()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty();
        }
    }
}
