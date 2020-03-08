using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Requests
{
    public class LogInsertRequest
    {
        public int UserId { get; set; }
        public byte[] Picture { get; set; }
        public DateTime? EnteredDate { get; set; }
        public DateTime? LeftDate { get; set; }
        public bool Entered { get; set; }
        public bool Left { get; set; }
    }
}
