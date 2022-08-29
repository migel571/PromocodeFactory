using FluentValidation;
using PromocodeFactory.Api.Commands;

namespace PromocodeFactory.Api.Validation
{
    public class CreateEmployeeValidator:AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(e => e.FirstName).NotNull().NotEmpty();
            RuleFor(e => e.LastName).NotNull().NotEmpty();
            RuleFor(e => e.Email).EmailAddress().NotNull().NotEmpty();
           
        }
    }
}
