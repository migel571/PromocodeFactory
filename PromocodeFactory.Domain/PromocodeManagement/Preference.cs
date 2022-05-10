namespace PromocodeFactory.Domain.PromocodeManagement
{   /// <summary>
    /// Связь один(Preference) ко многим(PromoCode) (у одного предпочтения много промокодов)
    /// 
    /// Связь многие(Preference) ко многим(Customers) (у одного предпочтения много клиентов и у клиента много предпочтений)
    /// соединено через доп таблицу CustomersPreference
    /// 
    /// </summary>
    public class Preference
    {
        public Guid PreferenceId { get; set; }
        public string Name { get; set; }

        public ICollection<PromoCode> PromoCodes { get; set; }

        public ICollection<CustomerPreference> CustomerPreferences { get; set; }

    }

}
