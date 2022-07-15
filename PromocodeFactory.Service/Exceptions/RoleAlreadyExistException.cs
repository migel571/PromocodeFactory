using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromocodeFactory.Service.Exceptions
{
    public class RoleAlreadyExistException : Exception
    {
        public RoleAlreadyExistException()
        {

        }
        public RoleAlreadyExistException(string message):base (message)
        {

        }
        public RoleAlreadyExistException(string message, Exception exception) :base (message,exception)
        {

        }
    }
}
