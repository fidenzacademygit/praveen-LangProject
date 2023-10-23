using Newtonsoft.Json;

namespace Data_Access_Layer.Models
{
    public class Address
    {
        public required string Id { get; set; }

        [JsonProperty("number")]
        public required int Number { get; set; }

        [JsonProperty("street")]
        public required string Street { get; set; }

        [JsonProperty("city")]
        public required string City { get; set; }

        [JsonProperty("state")]
        public required string State { get; set; }

        [JsonProperty("zipcode")]
        public required int Zipcode { get; set; }

        public required string CustomerId { get; set; }

        public Customer? Customer { get; set; }

    }
}
