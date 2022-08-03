using FluentValidation;
using PromocodeFactoryApi.Commands;

namespace PromocodeFactoryApi.Validation
{
    public class CreateEmployeeValidator:AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(e => e.FirstName).NotNull().NotEmpty();
            RuleFor(e => e.LastName).NotNull().NotEmpty();
            RuleFor(e => e.Email).EmailAddress().NotNull().NotEmpty();
            RuleFor(e=>e.RoleName).NotNull().NotEmpty();

        }
    }
}
