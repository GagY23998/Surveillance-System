using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Requests
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }

        public List<UserRoleDTO> UserRoles { get; set; } 
    }
}
