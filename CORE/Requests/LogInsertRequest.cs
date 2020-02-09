using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Requests
{
    public class LogInsertRequest
    {
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; }
        public int UserId { get; set; }
    }
}
