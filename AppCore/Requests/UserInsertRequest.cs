using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Requests
{
    public class UserInsertRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public List<RoleDTO> Roles { get; set; } = new List<RoleDTO>();
    }
}
