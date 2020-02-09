using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Models
{
    public class Label
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int UserLabel { get; set; }
    }
}
