using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    sealed class CubicFunction : GraphOfFunction, IFunction
    {
        public CubicFunction() : base()
        {
            TypeFunction = 2;
        }

        //Calculate value for line function
        public override int CalculateValue(int i)
        {
            return -i * i * i / 100;
        }
        public override string ToString()
        {
            return "f(x) = x*x*x";
        }
    }
}
