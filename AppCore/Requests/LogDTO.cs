using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Requests
{
    public class LogDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; }
        public int? UserId { get; set; }
        public UserDTO User { get; set; }
        public bool Entered { get; set; }
        public bool Left { get; set; }
        public byte[] Picture { get; set; }
    }
}
