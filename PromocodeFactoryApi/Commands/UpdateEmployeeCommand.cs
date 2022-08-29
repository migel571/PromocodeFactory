namespace PromocodeFactory.Api.Commands
{
    public class UpdateEmployeeCommand
    {
        public Guid EmployeeId { get; set; }    
        
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
        
        public string Email { get; set; }

    }
}
