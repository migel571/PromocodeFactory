using FluentValidation;
using PromocodeFactory.Api.Commands;

namespace PromocodeFactory.Api.Validation
{
    public class LoginUserValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserValidator()
        {
            RuleFor(r => r.Email).EmailAddress().NotNull().NotEmpty();
            RuleFor(r => r.Password).MinimumLength(6).NotNull().NotEmpty();
        }
    }
}
