using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromocodeFactory.Service.Exceptions
{
    public class UserException : Exception
    {
        public UserException()
        {

        }
        public UserException(string message) : base(message)
        {

        }
        public UserException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
