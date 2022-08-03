using System.ComponentModel.DataAnnotations;

namespace PromocodeFactoryApi.Commands
{
    public class CreateEmployeeCommand
    {
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }


        public Guid RoleId { get; set; }
       
        public string RoleName { get; set; }
        
        
    }
}
