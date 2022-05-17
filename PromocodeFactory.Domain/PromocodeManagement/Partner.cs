namespace PromocodeFactory.Domain.PromocodeManagement
{   /// <summary>
    /// Связь один(Partner) ко многим(PartnerPromoCodeLimit) (у одного партнера много лимитов на разные промокоды)
    /// </summary>
    public class Partner
    {
        public Guid PartnerId { get; set; }
        public string Name { get; set; } 
        
        public  int NumberIssuedPromoCode { get; set; } 

        public  bool IsActive { get; set; }

        public List<PartnerPromoCodeLimit> PartnerLimits { get; set; }
        
    }

    
}
