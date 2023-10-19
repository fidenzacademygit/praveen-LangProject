using Newtonsoft.Json;

namespace Customer_Data_API.Models.Domain
{
    public class Customer
    {
        [JsonProperty("_id")]
        public string? Id { get; set; }

        [JsonProperty("index")]
        public int? Index { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }

        [JsonProperty("eyeColor")]
        public string? EyeColor { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("gender")]
        public string? Gender { get; set; }

        [JsonProperty("company")]
        public string? Company { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("phone")]
        public string? Phone { get; set; }

        [JsonProperty("address")]
        public Address? Address { get; set; }

        [JsonProperty("about")]
        public string? About { get; set; }

        [JsonProperty("registered")]
        public string? Registered { get; set; }

        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("tags")]
        public List<string>? Tags { get; set; }
    }
}
