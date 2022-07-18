namespace PromocodeFactory.Service.Exceptions
{
    public class CustomerException : Exception
    {
        public CustomerException()
        {

        }
        public CustomerException(string message): base(message)
        {

        }
        public CustomerException(string message, Exception exception):base(message, exception)
        {

        }
    }
}
