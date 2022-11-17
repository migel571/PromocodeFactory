using System.ComponentModel.DataAnnotations;

namespace PromocodeFactory.UI.Models
{
    public class PreferenceModel
    {
        [Required]
        public Guid PreferenceId { get; set; }
        [Required(ErrorMessage = "Поле название предпочтения обязательное")]
        public string Name { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is PreferenceModel preference) return PreferenceId == preference.PreferenceId;
            return false;
        }
        public override int GetHashCode() => Name.GetHashCode();
    }
}
