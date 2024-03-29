﻿namespace PromocodeFactory.Domain.PromocodeManagement
{    /// <summary>
     /// Связь многие(Preference) ко многим(Customers) (у одного предпочтения много клиентов и у клиента много предпочтений)
     /// соединено через доп таблицу CustomersPreference
     ///
     /// Связь многие(Customer) ко многим(PromoCode) (у одного клиента много промокодов, у одного промокода много клиентов)
     /// </summary>
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ICollection<Preference> Preferences { get; set; }

        public ICollection<PromoCode> PromoCodes { get; set; }
    }

}
