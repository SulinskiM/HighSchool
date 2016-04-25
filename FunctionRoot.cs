using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class FunctionRoot : Graph
    {
        public FunctionRoot()
            : base()
        {
            for (int i = 0; i < 1000; i++)
                FieldFunction[i] = false;
        }

        public override int CountValue(int i)
        {
            return 0;
        }
    }
}
