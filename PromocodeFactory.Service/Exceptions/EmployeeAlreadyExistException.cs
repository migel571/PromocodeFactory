using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromocodeFactory.Service.Exceptions
{
    public class EmployeeAlreadyExistException : Exception
    {
        public EmployeeAlreadyExistException()
        {

        }
        public EmployeeAlreadyExistException(string message):base(message)
        {

            
        }
        public EmployeeAlreadyExistException(string message, Exception exception):base(message, exception)
        {

        }
    }
}
