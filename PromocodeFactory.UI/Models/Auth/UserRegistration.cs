using PromocodeFactory.UI.Attributes;
using System.ComponentModel.DataAnnotations;

namespace PromocodeFactory.UI.Models.Auth
{
    public class UserRegistration
    {
        [Required(ErrorMessage = "Поле UserName обязательное.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле Email обязательное.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Поле Password обязательное")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string ConfirmPassword { get; set; }

        //[RoleName]
        public string Role { get; set; }
        


    }
}
