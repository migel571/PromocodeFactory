namespace PromocodeFactoryApi.Commands
{
    public class CreatePartnerCommand
    {
        public string Name { get; set; }
        public int NumberIssuedPromoCode { get; set; }
        public bool IsActive { get; set; }
    }
}
