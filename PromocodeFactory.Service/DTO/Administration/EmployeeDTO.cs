namespace PromocodeFactory.Service.DTO.Administration
{
    public class EmployeeDTO
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        public Guid RoleId { get; set; }
       
        public int AppliedPromocodesCount { get; set; }
    }
}
