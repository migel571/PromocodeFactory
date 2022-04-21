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

        /// <summary>
        /// Fluent API
        /// hasone(many) - связь данной сущности к другой 
        /// withone(many) - обратная связь 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Конфигурация сущности Employee
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Employee>().Property(p => p.Email).HasMaxLength(20);
            modelBuilder.Entity<Employee>().Property(p => p.FirstName).HasMaxLength(20);
            modelBuilder.Entity<Employee>().Property(p => p.LastName).HasMaxLength(20);
            modelBuilder.Entity<Employee>().HasOne(p=>p.Role);
            
            //Конфигурация сущности Role
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Role>().Property(p => p.RoleName).HasMaxLength(15);

            //Конфигурация сущности Customer
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Customer>().Property(p => p.FirstName).HasMaxLength(20);
            modelBuilder.Entity<Customer>().Property(p => p.LastName).HasMaxLength(20);
            modelBuilder.Entity<Customer>().Property(p => p.Email).HasMaxLength(20);
            modelBuilder.Entity<Customer>().HasMany(p => p.Preferences).WithMany(p=>p.Customers);
            modelBuilder.Entity<Customer>().HasOne(p => p.PromoCode).WithMany(p => p.Customers);

            //Конфигурация сущности Preference
            modelBuilder.Entity<Preference>().ToTable("Preference");
            modelBuilder.Entity<Preference>().Property(p => p.Name).HasMaxLength(100);

            //Конфигурация сущности PromoCode
            modelBuilder.Entity<PromoCode>().ToTable("PromoCode");
            modelBuilder.Entity<PromoCode>().Property(p=>p.Code).HasMaxLength(100);
            modelBuilder.Entity<PromoCode>().Property(p => p.PartnerName).HasMaxLength(20);
            modelBuilder.Entity<PromoCode>().HasOne(p=>p.Preference);


        }
    }

}
