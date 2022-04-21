using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromocodeFactory.Domain.PromocodeManagement
{
    public class Partner
    {
        public string Name { get; set; }    
        public  int NumberIssuedPromoCode { get; set; } 
        public  bool IsActive { get; set; }
        public List<PartnerPromoCodeLimit> PartnerLimits { get; set; }
        public List<PromoCode> PromoCodes { get; set; }
    }

    
}
