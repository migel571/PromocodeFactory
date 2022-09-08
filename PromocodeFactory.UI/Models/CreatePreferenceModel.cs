using System.ComponentModel.DataAnnotations;

namespace PromocodeFactory.UI.Models
{
    public class CreatePreferenceModel
    {
        [Required(ErrorMessage ="Поле название предпочтения обязательное")]
        public string Name { get; set; }
    }
}
