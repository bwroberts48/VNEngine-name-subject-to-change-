﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNEngine
{
    public class GraphException : Exception
    {
        public GraphException(string message) : base(message)
        { }
    }
}
