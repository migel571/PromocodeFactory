using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.Administaration;
using PromocodeFactory.Domain.PromocodeManagement;

namespace PromocodeFactory.Infrastructure
{
    public class PromocodeContext : DbContext
    {
        public PromocodeContext(DbContextOptions<PromocodeContext> options)
            : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee").Property(p => p.Email).HasMaxLength(10);
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Preference>().ToTable("Preference");
            modelBuilder.Entity<PromoCode>().ToTable("PromoCode");


        }
    }

}
