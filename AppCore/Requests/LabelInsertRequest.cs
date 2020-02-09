﻿using AppCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Requests
{
    public class LabelInsertRequest
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int UserLabel { get; set; }
    }
}
