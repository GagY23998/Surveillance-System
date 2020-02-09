using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Requests
{
    public class UserInsertRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Image { get; set; }
    }
}
