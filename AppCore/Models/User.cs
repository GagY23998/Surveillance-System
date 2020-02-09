using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public string Token { get; set; }
    }
}
