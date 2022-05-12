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
            modelBuilder.Entity<Employee>().HasOne<Role>(p => p.Role).
                                            WithMany(p => p.Employees).
                                            HasForeignKey(p => p.RoleId);

            //Конфигурация сущности Role
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Role>().Property(p => p.RoleName).HasMaxLength(15);


            //Конфигурация сущности Customer
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Customer>().Property(p => p.FirstName).HasMaxLength(20);
            modelBuilder.Entity<Customer>().Property(p => p.LastName).HasMaxLength(20);
            modelBuilder.Entity<Customer>().Property(p => p.Email).HasMaxLength(20);



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
            modelBuilder.Entity<PromoCode>().HasOne<Customer>(p => p.Customer).
                                             WithMany(p => p.PromoCodes).
                                             HasForeignKey(p => p.CustomerId);

            //Конфигурация сущности CustomerPreference - сводная таблица для связи многие ко многим
            modelBuilder.Entity<CustomerPreference>().ToTable("CustomerPreference");
            modelBuilder.Entity<CustomerPreference>().HasKey(p => new { p.PreferenceId, p.CustomerId });
            modelBuilder.Entity<CustomerPreference>().HasOne<Customer>(p => p.Customer).
                                                      WithMany(p => p.CustomerPreferences).
                                                      HasForeignKey(p => p.CustomerId);
            modelBuilder.Entity<CustomerPreference>().HasOne<Preference>(p => p.Preference).
                                                      WithMany(p => p.CustomerPreferences).
                                                      HasForeignKey(p => p.PreferenceId);

            //Конфигурация сущности Partner 
            modelBuilder.Entity<Partner>().ToTable("Partner");
            modelBuilder.Entity<Partner>().Property(p=>p.Name).HasMaxLength(20);

            //Конфигурация сущности PartnerPromoCodeLimit
            modelBuilder.Entity<PartnerPromoCodeLimit>().ToTable("PartnerPromoCodeLimit");
            modelBuilder.Entity<PartnerPromoCodeLimit>().HasOne<Partner>(p=>p.Partner).
                                                         WithMany(p=>p.PartnerLimits).
                                                         HasForeignKey(p=>p.PartnerId);

        }
    }

}
