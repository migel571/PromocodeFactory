namespace PromocodeFactory.Domain.PromocodeManagement
{
    /// <summary>
    /// Связь многие(Preference) ко многим(Customers) (у одного предпочтения много клиентов и у клиента много предпочтений)
    /// соединено через доп таблицу CustomersPreference
    /// </summary>
    public class CustomerPreference
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public Guid PreferenceId { get; set; }
        public Preference Preference { get; set; }
    }
}
