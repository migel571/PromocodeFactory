using System.ComponentModel.DataAnnotations;

namespace PromocodeFactory.UI.Models
{
    public class UpdateCustomerModel
    {
        [Required]
        public Guid CustomerId { get; set; }
        [Required(ErrorMessage = "Поле имя обязательное")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Поле фамилия обязательное")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Поле email обязательное")]
        public string Email { get; set; }

        public List<Guid> PreferenceIds { get; set; }

    }
}
