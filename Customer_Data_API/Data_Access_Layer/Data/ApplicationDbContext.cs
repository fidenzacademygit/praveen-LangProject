using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
            .HasOne<Address>(s => s.Address)
            .WithOne(ad => ad.Customer)
            .HasForeignKey<Address>(ad => ad.CustomerId);
            modelBuilder.Entity<Customer>().HasData(CustomerDataSeed.CustomData());
            modelBuilder.Entity<Address>().HasData(AddressDataSeed.AddressData());

        }
    }
}
