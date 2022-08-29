using FluentValidation;
using PromocodeFactory.Api.Commands;

namespace PromocodeFactory.Api.Validation
{
    public class RegistrationUserValidator : AbstractValidator<RegistrationUserCommand>
    {
        public RegistrationUserValidator()
        {
            RuleFor(r => r.UserName).NotNull().NotEmpty();
            RuleFor(r=>r.Email).EmailAddress().NotNull().NotEmpty();
            RuleFor(r=>r.Password).MinimumLength(6).NotNull().NotEmpty();
            RuleFor(r => r.ConfirmPassword).MinimumLength(6).NotNull().NotEmpty();
        }
    }
}
