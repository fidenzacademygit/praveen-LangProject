﻿namespace Customer_Data_API.Models.Dtos.UserDtos
{
    public class UserCustomerDetailsDto
    {
        public string? Id { get; set; }

        public int? Age { get; set; }

        public string? EyeColor { get; set; }

        public string? Name { get; set; }

        public string? Gender { get; set; }

        public string? Company { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public AddressDto? Address { get; set; }

        public string? About { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

    }
    public class AddressDto
    {
        public int? Number { get; set; }

        public string? Street { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public int? Zipcode { get; set; }
    }
}
