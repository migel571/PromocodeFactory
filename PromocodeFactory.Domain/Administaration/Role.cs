namespace PromocodeFactory.Domain.Administaration
{   
    /// <summary>
    /// Связь один(Role) ко многим(Employee) (у одной роли много сотрудников)
    /// </summary>
    public class Role
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }

}
