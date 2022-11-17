namespace PromocodeFactory.Domain.PromocodeManagement
{   
    public class Partner
    {
        public Guid PartnerId { get; set; }
        public string Name { get; set; }
        public int NumberIssuedPromoCode { get; set; }
        public bool IsActive { get; set; }
        

    }


}
