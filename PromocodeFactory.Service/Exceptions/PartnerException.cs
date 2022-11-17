namespace PromocodeFactory.Service.Exceptions
{
    public class PartnerException:Exception
    {
        public PartnerException()
        {

        }
        public PartnerException(string message):base(message)
        {

        }
        public PartnerException(string message, Exception exception):base(message,exception)
        {

        }
    }
}
