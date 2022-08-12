using FluentValidation;
using PromocodeFactoryApi.Commands;

namespace PromocodeFactoryApi.Validation
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
