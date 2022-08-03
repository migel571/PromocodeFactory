using FluentValidation;
using PromocodeFactoryApi.Commands;

namespace PromocodeFactoryApi.Validation
{
    public class CreateCustomerValidator:AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(c=>c.FirstName).NotNull().NotEmpty();
            RuleFor(c => c.LastName).NotNull().NotEmpty();
            RuleFor(c => c.Email).EmailAddress().NotNull().NotEmpty();
        }
    }
}
