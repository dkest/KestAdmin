﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kest.Domain.Models
{
    public class User:Entity
    {
        public string Name { get; private set; }
        public string Password { get; private set; }
    }
}
