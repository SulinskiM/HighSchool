using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    sealed class RootFunction : GraphOfFunction, IFunction
    {
        public RootFunction() : base()
        {
            TypeFunction = 3;
            ChangeField();
        }
        public void ChangeField()
        {
            for (int i = 0; i < 1000; i++)
                Value[i].Belong = false;
        }

        //Calculate value for line function
        public override int CalculateValue(int i)
        {
            if (i > 0)
                return -(int)(Math.Sqrt((double)i*10));
            else
                return 1;
        }
        public override string ToString()
        {
            return "f(x) = Sgrt(x)";
        }
    }
}
