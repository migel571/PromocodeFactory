namespace PromocodeFactory.Api.Commands
{
    public class UpdateCustomerCommand
    {
        public Guid CustomerId { get; set; }    
       
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }

        public List<Guid> PreferenceIds { get; set; }
        
    }
}
