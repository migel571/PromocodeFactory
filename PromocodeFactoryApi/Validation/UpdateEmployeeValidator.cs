using FluentValidation;
using PromocodeFactory.Api.Commands;

namespace PromocodeFactory.Api.Validation
{
    public class UpdateEmployeeValidator:AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(e => e.FirstName).NotNull().NotEmpty();
            RuleFor(e => e.LastName).NotNull().NotEmpty();
            RuleFor(e => e.Email).EmailAddress().NotNull().NotEmpty();
        }
    }
}
