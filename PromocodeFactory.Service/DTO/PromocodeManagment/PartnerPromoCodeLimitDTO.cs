namespace PromocodeFactory.Service.DTO.PromocodeManagment
{
    public class PartnerPromoCodeLimitDTO
    {
        public Guid PartnerPromoCodeLimitId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? CancelDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Limit { get; set; }


        public Guid PartnerId { get; set; }
       
    }
}
