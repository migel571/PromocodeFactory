using FluentValidation;
using PromocodeFactory.Api.Commands;

namespace PromocodeFactory.Api.Validation
{
    public class UpdatePreferenceValidator : AbstractValidator<UpdatePreferenceCommand>
    {
        public UpdatePreferenceValidator()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty();
        }
    }
}
