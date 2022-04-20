using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromocodeFactory.Domain.PromocodeManagement
{
    public class PromoCode
    {
        public Guid PromoCodeId { get; set; }
        public string Code { get; set; }
        public string ServiceInfo { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PartnerName { get; set; }
        public Preference Preference { get; set; }
        public List<Customer> Customers { get; set; }
    }

}
