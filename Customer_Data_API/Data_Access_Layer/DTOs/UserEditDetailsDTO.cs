using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.DTOs
{
    public class UserEditDetailsDTO
    {
        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Phone { get; set; }
    }
}
