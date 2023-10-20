using Customer_Data_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Customer_Data_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
            .HasOne<Address>(s => s.Address)
            .WithOne(ad => ad.Customer)
            .HasForeignKey<Address>(ad => ad.CustomerId);
            modelBuilder.Entity<Customer>().HasData(CustomerDataSeeder.CustomData());
            modelBuilder.Entity<Address>().HasData(AddressDataSeeder.AddressData());
        }
    }
}
