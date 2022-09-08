using System.ComponentModel.DataAnnotations;

namespace PromocodeFactory.UI.Models
{
    public class PreferenceModel
    {
        [Required]
        public Guid PreferenceId { get; set; }
        [Required(ErrorMessage = "Поле название предпочтения обязательное")]
        public string Name { get; set; }
    }
}
