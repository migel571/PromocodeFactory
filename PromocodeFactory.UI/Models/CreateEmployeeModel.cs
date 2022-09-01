using System.ComponentModel.DataAnnotations;

namespace PromocodeFactory.UI.Models
{
    public class CreateEmployeeModel
    {
        [Required(ErrorMessage="Поле Имя обязательное")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле Фамилия обязательное")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле Email обязательное")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Введите правильно Email адрес")]
        public string Email { get; set; }
    }
}
