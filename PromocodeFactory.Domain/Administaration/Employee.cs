namespace PromocodeFactory.Domain.Administaration
{   
    /// <summary>
    /// Связь один(Role) ко многим(Employee) (у одной роли много сотрудников)
    /// </summary>
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        

        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public int AppliedPromocodesCount { get; set; }
    }

}
