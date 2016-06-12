using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    //TODO: Properties line function
    public struct PropertiesLineFunction
    {
        public double A { get; set; }
        public double B { get; set; }

        public PropertiesLineFunction(double a, double b)
        {
            A = a;
            B = b;
        }
    }
    sealed class LineFunction : GraphOfFunction, IFunction
    {
        public LineFunction() : base()
        {
            TypeFunction = 0;
        }
        public LineFunction(PropertiesLineFunction prop)
        {
            Value = new PointGraph[QuantilyPoint];
            ActualVector = new Vector();
            CreateFunction(prop);
        }

        //Calculate value for line function
        public override int CalculateValue(int i)
        {
            return -i;
        }
        public void CreateFunction(PropertiesLineFunction prop)
        {
            for (int i = 0; i < QuantilyPoint; i++)
            {
                Value[i].Belong = true; //Default each point belong down graph
                Value[i].X = i - 1000;
                Value[i].Y = (int)(-(prop.A*(i-1000) + prop.B));
            }
        }

        //TODO: Made pattern line function
        public override string ToString()
        {
            if (FunctionPowerValue == 1)
                return "f(x) = x + " + Convert.ToString((ActualVector.X + ActualVector.Y) / 10);
            else
            {
                if ((FunctionPowerValue * (ActualVector.X + ActualVector.Y) / 10) > 0)
                    return "f(x) = " + Convert.ToString(FunctionPowerValue) + "*x+" + Convert.ToString(FunctionPowerValue * (ActualVector.X + ActualVector.Y) / 10);
                else
                    return "f(x) = " + Convert.ToString(FunctionPowerValue) + "*x" + Convert.ToString(FunctionPowerValue * (ActualVector.X + ActualVector.Y) / 10);
            }
        }
    }
}
