using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromocodeFactory.Service.Exceptions
{
    public class PromoCodeException:Exception
    {
        public PromoCodeException()
        {

        }
        public PromoCodeException(string message) : base(message)
        {

        }
        public PromoCodeException(string message, Exception exception):base(message, exception) 
        {

        }
    }
}
