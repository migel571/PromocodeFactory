using System.ComponentModel.DataAnnotations;

namespace PromocodeFactoryApi.Commands
{
    public class UpdateRoleCommand
    {
        public Guid RoleId { get; set; }
        
        public string RoleName { get; set; }
        
        public string Description { get; set; }
    }
}
