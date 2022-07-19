using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromocodeFactory.Service.Exceptions
{
    public class PreferenceException:Exception
    {
        public PreferenceException()
        {

        }
        public PreferenceException(string message):base(message)
        {

        }
        public PreferenceException(string message, Exception exception):base(message, exception)
        {

        }
    }
}
