using System.ComponentModel.DataAnnotations.Schema;

namespace Customer_Data_API.Models.Domain
{
    public class Customer
    {
        public string? Id { get; set; }

        public int? Index { get; set; }

        public int? Age { get; set; }

        public string? EyeColor { get; set; }

        public string? Name { get; set; }

        public string? Gender { get; set; }

        public string? Company { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public Address? Address { get; set; }

        public string? About { get; set; }

        public string? Registered { get; set; }

        public double? Latitude { get; set; }

        [NotMapped]
        public List<string>? Tags { get; set; }

        public double? Longitude { get; set; }

    }
}
