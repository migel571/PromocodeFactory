using System.ComponentModel.DataAnnotations;

namespace PromocodeFactory.UI.Models.Auth
{
    public class UserAuthentication
    {
        [Required(ErrorMessage = "Поле Email обязательное.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Поле Password обязательное")]
        public string Password { get; set; }
    }
}
