using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Data_API.Domain.Entities
{
	public class Customer
	{
		public required string Id { get; set; }
		public required int Index { get; set; }
		public required int Age { get; set; }
		public required string EyeColor { get; set; }
		public required string Name { get; set; }
		public required string Gender { get; set; }
		public required string Company { get; set; }
		public required string Email { get; set; }
		public required string Phone { get; set; }
		public required Address Address { get; set; }
		public required string About { get; set; }
		public required DateTime Registered { get; set; }
		public required double Latitude { get; set; }
		public required double Longitude { get; set; }
		public required List<string> Tags { get; set; }
	}
	public class Address
	{
		public required int Number { get; set; }
		public required string Street { get; set; }
		public required string City { get; set; }
		public required string State { get; set; }
		public required int Zipcode { get; set; }
	}
}
