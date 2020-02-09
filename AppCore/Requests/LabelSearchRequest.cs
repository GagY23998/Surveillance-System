using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Requests
{
    public class LabelSearchRequest
    {
        public int UserId { get; set; }
        public int UserLabel { get; set; }
    }
}
