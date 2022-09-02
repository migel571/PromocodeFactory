using System.ComponentModel.DataAnnotations;

namespace PromocodeFactory.UI.Models
{
    public class PartnerModel
    {
        [Required]
        public Guid PartnerId { get; set; }
        [Required(ErrorMessage = "Поле Имя обязательное")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле кол-во промокодов обязательное")]
        public int NumberIssuedPromoCode { get; set; }
        [Required(ErrorMessage = @"Поле ""действующий"" обязательное")]
        public bool IsActive { get; set; }

    }
}
