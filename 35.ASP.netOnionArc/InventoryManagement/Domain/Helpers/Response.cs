﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public class Response<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}