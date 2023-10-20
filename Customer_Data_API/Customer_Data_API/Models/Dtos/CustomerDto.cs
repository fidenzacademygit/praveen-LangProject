using Customer_Data_API.Models.Domain;
using Newtonsoft.Json;

namespace Customer_Data_API.Models.Dtos
{
    public class CustomerDto
    {
        [JsonProperty("_id")]
        public string? Id { get; set; }

        [JsonProperty("index")]
        public int? Index { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("phone")]
        public string? Phone { get; set; }

    }
}
