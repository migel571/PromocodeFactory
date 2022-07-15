using System.ComponentModel.DataAnnotations;

namespace PromocodeFactoryApi.Commands
{
    public class UpdateEmployeeCommand
    {
        public Guid EmployeeId { get; set; }    
        [Required(ErrorMessage = "FirstName of employee is requered")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName of employee is requered")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email of employee is requered")]
        public string Email { get; set; }


        public Guid RoleId { get; set; }
        [Required(ErrorMessage = "RoleName of employee is requered")]
        public string RoleName { get; set; }
        [Required(ErrorMessage = "AppliedPromocodesCount of employee is requered")]
        public int AppliedPromocodesCount { get; set; }
    }
}
