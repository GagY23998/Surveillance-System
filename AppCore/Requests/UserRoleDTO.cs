using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Requests
{
    public class UserRoleDTO
    {
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public int RoleId { get; set; }
        public RoleDTO Role { get; set; }
    }
}
