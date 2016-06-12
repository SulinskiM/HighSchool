using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public struct PropertiesQuadraticFunction
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public PropertiesQuadraticFunction(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }
    }
    class QuadraticFunction : GraphOfFunction, IFunction
    {
        PropertiesQuadraticFunction properties;
        public QuadraticFunction() : base()
        {

        }
        public QuadraticFunction(PropertiesQuadraticFunction prop)
        {
            Value = new PointGraph[QuantilyPoint];
            ActualVector = new Vector();
            CreateFunction(prop);
            properties = new PropertiesQuadraticFunction(0, 0, 0);
            properties = prop;
        }
        public void CreateFunction(PropertiesQuadraticFunction prop)
        {
            for (int i = 0; i < QuantilyPoint; i++)
            {
                int argument = i - 1000;
                Value[i].Belong = true; //Default each point belong down graph
                Value[i].X = i - 1000;
                if(argument!=0)
                Value[i].Y = -(int)(prop.A * argument * argument / 10 + prop.B * argument + prop.C * 10);
            }
        }
        //Calculate value for line function
        public override int CalculateValue(int i)
        {
            return -i * i / 10;
        }
        public override string ToString()
        {
            string pattern = "f(x) = ";
            if (properties.A != 0)
            {
                if (properties.A != 1)
                {
                    if (properties.A < 0)
                        pattern += "- " + Convert.ToString(Math.Abs(properties.A)) + " * x * x ";
                }
                else
                    pattern += "(x * x) ";
            }
            if (properties.B != 0)
            {
                if (properties.B != 1)
                {
                    if (properties.B < 0)
                        pattern += "- ";
                    else
                        pattern += "+ ";
                    pattern += Convert.ToString(Math.Abs(properties.B)) + " * x ";
                }
                else
                    pattern += "+ x ";
            }
            if (properties.C != 0)
            {
                if (properties.C < 0)
                    pattern += "- ";
                else
                    pattern += "+ ";
                pattern += Convert.ToString(Math.Abs(properties.C));
            }

            return pattern;
        }
    }
}
