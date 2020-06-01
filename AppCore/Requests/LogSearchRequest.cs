using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Requests
{
    public class LogSearchRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool? Entered { get; set; }
        public bool? Left { get; set; }
    }
}
