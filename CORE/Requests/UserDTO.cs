using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Requests
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Image { get; set; }
    }
}
