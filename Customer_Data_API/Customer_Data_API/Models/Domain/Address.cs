namespace Customer_Data_API.Models.Domain
{
    public class Address
    {
        public string? Id { get; set; }

        public int Number { get; set; }

        public string? Street { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public int Zipcode { get; set; }

        public string? CustomerId { get; set; }

        public Customer? Customer { get; set; }

    }
}
