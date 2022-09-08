using System.ComponentModel.DataAnnotations;

namespace PromocodeFactory.UI.Models
{
    public class CreatePromocodeModel
    {
        [Required]
        public Guid PromocodeId { get; set; }
        [Required(ErrorMessage = "Поле код обязательное")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Поле информация обязательное")]
        public string ServiceInfo { get; set; }
        [Required(ErrorMessage = "Поле начало действия промокода обязательное")]
        public DateTime BeginDate { get; set; }
        [Required(ErrorMessage = "Поле конец действия промокода обязательное")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Поле название партнера обязательное")]
        public string PartnerName { get; set; }
    }
}
