﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Image { get; set; }
    }
}
