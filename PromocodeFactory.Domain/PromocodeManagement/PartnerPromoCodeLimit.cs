namespace PromocodeFactory.Domain.PromocodeManagement
{   /// <summary>
    /// Связь один(Partner) ко многим(PartnerPromoCodeLimit) (у одного партнера много лимитов на разные промокоды)
    /// </summary>
    public class PartnerPromoCodeLimit
    {
        public Guid PartnerPromoCodeLimitId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? CancelDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Limit { get; set; }


        public Guid PartnerId { get; set; }
        public virtual Partner Partner { get; set; }

    }
}
