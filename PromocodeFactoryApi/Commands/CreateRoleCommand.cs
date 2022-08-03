using System.ComponentModel.DataAnnotations;

namespace PromocodeFactoryApi.Commands
{
    public class CreateRoleCommand
    {
        
        public string RoleName { get; set; }
        
        public string Description { get; set; }
    }
}
