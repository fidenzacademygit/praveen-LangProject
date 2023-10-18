using Customer_Data_API.Domain.Entities;
using Newtonsoft.Json;

namespace Customer_Data_API.Infrastructure.Data
{
	public static class CustomerDataSeeder
	{
		public static List<Customer> CustomData()
		{
			var customerData = new List<Customer>();
			using (StreamReader r = new(@"UserData.json"))
			{
				string json = r.ReadToEnd();
				customerData = JsonConvert.DeserializeObject<List<Customer>>(json);
			}

			var customerSeedData = new List<Customer>();

			foreach (var customer in customerData)
			{
				var add = new Customer
				{
					Id = customer.Id,
					Index = customer.Index,
					Age = customer.Age,
					EyeColor = customer.EyeColor,
					Name = customer.Name,
					Gender = customer.Gender,
					Company = customer.Company,
					Email = customer.Email,
					Phone = customer.Phone,
					About = customer.About,
					Registered = customer.Registered,
					Latitude = customer.Latitude,
					Longitude = customer.Longitude,
					Tags = customer.Tags,
				};
				customerSeedData.Add(add);
			}
			return customerSeedData;
		}
	}
}
