﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class QuadraticFunction : Graph
    {
        public override int CountValue(int i)
        {
            return -i*i;
        }
    }
}
