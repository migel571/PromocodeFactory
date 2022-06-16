namespace PromocodeFactory.Service.DTO.PromocodeManagment
{
    public class PartnerDTO
    {
        public Guid PartnerId { get; set; }
        public string Name { get; set; }
        public int NumberIssuedPromoCode { get; set; }
        public bool IsActive { get; set; }
       
    }
}
