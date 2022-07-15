using System.ComponentModel.DataAnnotations;

namespace PromocodeFactoryApi.Commands
{
    public class CreateRoleCommand
    {
        [Required(ErrorMessage ="Name of role is requered")]
        public string RoleName { get; set; }
        [Required(ErrorMessage = "Description of role is requered")]
        public string Description { get; set; }
    }
}
