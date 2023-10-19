using Newtonsoft.Json;

namespace Customer_Data_API.Domain.Entities
{
	public class Address
	{
		public string? Id { get; set; }

		[JsonProperty("number")]
		public int Number { get; set; }

		[JsonProperty("street")]
		public string? Street { get; set; }

		[JsonProperty("city")]
		public string? City { get; set; }

		[JsonProperty("state")]
		public string? State { get; set; }

		[JsonProperty("zipcode")]
		public int Zipcode { get; set; }

		public string? CustomerId { get; set; }

		public Customer? Customer { get; set; }

	}
}
