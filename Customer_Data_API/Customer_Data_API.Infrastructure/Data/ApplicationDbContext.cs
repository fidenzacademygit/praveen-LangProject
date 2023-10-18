using Customer_Data_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Customer_Data_API.Infrastructure.Data
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
			modelBuilder.Entity<Customer>().HasData(CustomerDataSeeder.CustomData());
			modelBuilder.Entity<Address>().HasData(AddressDataSeeder.AddressData());
		}
	}
}

