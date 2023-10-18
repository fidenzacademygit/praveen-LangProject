﻿using Customer_Data_API.Domain.Entities;
using Newtonsoft.Json;

namespace Customer_Data_API.Infrastructure.Data
{
	public static class AddressDataSeeder
	{
		public static List<Address> AddressData()
		{
			var customerData = new List<Customer>();
			using (StreamReader r = new(@"UserData.json"))
			{
				string json = r.ReadToEnd();
				customerData = JsonConvert.DeserializeObject<List<Customer>>(json);
			}
			var addressSeedData = new List<Address>();

			foreach (var customer in customerData)
			{
				var addAddress = new Address
				{
					Id = customer.Id,
					CustomerId = customer.Id,
					Number = customer.Address.Number,
					Street = customer.Address.Street,
					City = customer.Address.City,
					State = customer.Address.State,
					Zipcode = customer.Address.Zipcode,
				};

				addressSeedData.Add(addAddress);
			}
			return addressSeedData;
		}
	}
}
