using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromocodeFactory.Domain.PromocodeManagement
{
    public class Preference
    {
        public Guid PreferenceId { get; set; }
        public string Name { get; set; }
        public PromoCode PromoCode { get; set; }
        public List<Customer> Customers { get; set; }
    }

}
