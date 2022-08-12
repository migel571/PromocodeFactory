using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.Administaration;
using PromocodeFactory.Domain.PromocodeManagement;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace PromocodeFactory.Infrastructure
{
    public class PromocodeContext : IdentityDbContext
    {
        public PromocodeContext(DbContextOptions<PromocodeContext> options)
            : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        public DbSet<Partner> Partners { get; set; }
        

        /// <summary>
        /// Fluent API
        /// hasone(many) - связь данной сущности к другой 
        /// withone(many) - обратная связь 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Конфигурация сущности Employee
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Employee>().Property(p => p.Email).HasMaxLength(20);
            modelBuilder.Entity<Employee>().Property(p => p.FirstName).HasMaxLength(20);
            modelBuilder.Entity<Employee>().Property(p => p.LastName).HasMaxLength(20);
            



            //Конфигурация сущности Customer
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Customer>().Property(p => p.FirstName).HasMaxLength(20);
            modelBuilder.Entity<Customer>().Property(p => p.LastName).HasMaxLength(20);
            modelBuilder.Entity<Customer>().Property(p => p.Email).HasMaxLength(20);
            modelBuilder.Entity<Customer>().HasMany<Preference>(p => p.Preferences).WithMany(p => p.Customers);



            //Конфигурация сущности Preference
            modelBuilder.Entity<Preference>().ToTable("Preference");
            modelBuilder.Entity<Preference>().Property(p => p.Name).HasMaxLength(100);

            //Конфигурация сущности PromoCode
            modelBuilder.Entity<PromoCode>().ToTable("PromoCode");
            modelBuilder.Entity<PromoCode>().Property(p => p.Code).HasMaxLength(100);
            modelBuilder.Entity<PromoCode>().Property(p => p.PartnerName).HasMaxLength(20);
            modelBuilder.Entity<PromoCode>().HasOne<Preference>(p => p.Preference).
                                             WithMany(p => p.PromoCodes).
                                             HasForeignKey(p => p.PreferenceId);
            modelBuilder.Entity<PromoCode>().HasMany<Customer>(p => p.Customers).
                                             WithMany(p => p.PromoCodes);
                                             

            

            //Конфигурация сущности Partner 
            modelBuilder.Entity<Partner>().ToTable("Partner");
            modelBuilder.Entity<Partner>().Property(p=>p.Name).HasMaxLength(20);

           

        }
    }

}
