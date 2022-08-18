namespace PromocodeFactory.Service.DTO.PromocodeManagment
{
    public class PromoCodeDTO
    {
        public Guid PromoCodeId { get; set; }
        public string Code { get; set; }
        public string ServiceInfo { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PartnerName { get; set; }

        public Guid PreferenceId { get; set; }
        

    }
}
