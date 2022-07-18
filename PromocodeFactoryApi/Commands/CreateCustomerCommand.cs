using System.ComponentModel.DataAnnotations;

namespace PromocodeFactoryApi.Commands
{
    public class CreateCustomerCommand
    {
       
        [Required(ErrorMessage = "FirstName of customer is requered")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName of customer is requered")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email of customer is requered")]
        public string Email { get; set; }

        public List<Guid> PreferenceIds { get; set; }

    }
}
