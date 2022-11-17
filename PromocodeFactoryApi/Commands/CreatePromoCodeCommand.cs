namespace PromocodeFactory.Api.Commands
{
    public class CreatePromoCodeCommand
    {
        
        public string Code { get; set; }
        public string ServiceInfo { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PartnerName { get; set; }

        public Guid PreferenceId { get; set; }
        
       
    }
}
