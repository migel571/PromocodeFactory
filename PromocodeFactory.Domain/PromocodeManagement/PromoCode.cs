namespace PromocodeFactory.Domain.PromocodeManagement
{   /// <summary>
    /// Связь один(Preference) ко многим(PromoCode) (у одного предпочтения много промокодов)
    ///
    /// Связь многие(Customer) ко многим(PromoCode) (у одного клиента много промокодов, у одного промокода много клиентов)
    /// </summary>
    public class PromoCode
    {
        public Guid PromoCodeId { get; set; }
        public string Code { get; set; }
        public string ServiceInfo { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PartnerName { get; set; }

        public Guid PreferenceId { get; set; }  
        public Preference Preference { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }

}
