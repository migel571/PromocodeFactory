using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromocodeFactory.Service.Exceptions
{
    public class EmployeeException : Exception
    {
        public EmployeeException()
        {

        }
        public EmployeeException(string message):base(message)
        {

            
        }
        public EmployeeException(string message, Exception exception):base(message, exception)
        {

        }
    }
}
