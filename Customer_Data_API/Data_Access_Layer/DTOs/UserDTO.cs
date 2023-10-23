using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.DTOs
{
    public class UserDTO
    {
        public required string Id { get; set; }

        public required int Age { get; set; }

        public required string EyeColor { get; set; }

        public required string Name { get; set; }

        public required string Gender { get; set; }

        public required string Company { get; set; }

        public required string Email { get; set; }

        public required string Phone { get; set; }

        public required AddressDTO Address { get; set; }

        public required string About { get; set; }

        public required double Latitude { get; set; }

        public required double Longitude { get; set; }
    }
}
