using Newtonsoft.Json;

namespace Data_Access_Layer.Models
{
    public class Customer
    {
        [JsonProperty("_id")]
        public required string Id { get; set; }

        [JsonProperty("index")]
        public required int Index { get; set; }

        [JsonProperty("age")]
        public required int Age { get; set; }

        [JsonProperty("eyeColor")]
        public required string EyeColor { get; set; }

        [JsonProperty("name")]
        public required string Name { get; set; }

        [JsonProperty("gender")]
        public required string Gender { get; set; }

        [JsonProperty("company")]
        public required string Company { get; set; }

        [JsonProperty("email")]
        public required string Email { get; set; }

        [JsonProperty("phone")]
        public required string Phone { get; set; }

        [JsonProperty("address")]
        public Address? Address { get; set; }

        [JsonProperty("about")]
        public required string About { get; set; }

        [JsonProperty("registered")]
        public required string Registered { get; set; }

        [JsonProperty("latitude")]
        public required double Latitude { get; set; }

        [JsonProperty("longitude")]
        public required double Longitude { get; set; }

        [JsonProperty("tags")]
        public required List<string> Tags { get; set; }
    }
}
