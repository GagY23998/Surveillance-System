using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Requests
{
    public class UserRoleSearchRequest
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
