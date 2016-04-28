using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    interface IFunction
    {
        int CalculateValue(int i);
        void TransformAboutvector(Vector vector);
        void SymmetryOX();
        void SymmetryOY();
        void SymmetryPointZero();
        void AbsoluteValueFunction();
        void AbsoluteValueArgument();
        void PowerFunction(double power);
    }
}
