namespace Data_Access_Layer.DTOs
{
    public class AddressDTO
    {
        public required int Number { get; set; }

        public required string Street { get; set; }

        public required string City { get; set; }

        public required string State { get; set; }

        public required int Zipcode { get; set; }
    }
}
