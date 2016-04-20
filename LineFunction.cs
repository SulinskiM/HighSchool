using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class LineFunction:Graph
    {
        //public int A { get; set; }

        public LineFunction()
            :base()
        {
        }

        public override int CountValue(int i)
        {
            return -i;
        }
    }
}
