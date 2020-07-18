using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Requests
{
    public class LogDTO
    {
        public int Id { get; set; }
        public DateTime? EnteredDate { get; set; }
        public DateTime? LeftDate { get; set; }
        public int? UserId { get; set; }
        public UserDTO User { get; set; }
        public bool Entered { get; set; }
        public bool Left { get; set; }
        //public byte[] Picture { get; set; }
        public string Picture { get; set; }
    }
}
