using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    //Struct stores point graph
    struct PointGraph
    {
        public int X; //Position x
        public double Y; //Position y
        public bool Belong; //Is point belong down graph
        //If belong == true Point belong down grapf else point not belong graph
    }

    class Function 
    {
        public PointGraph[] Value; //Table which stores points graph
        protected const int QuantilyPoint = 2001; //Variable stores quantily points
        public Vector ActualVector { get; set; } //Properties which stores current displacement vector graph
        private double _functionPower = 1;
        public double FunctionPowerValue
        {
            get
            {
                return _functionPower;
            }
            set
            {
                if (value != 0)
                    _functionPower = value;
            }
        }
        public string Transform { get; set; } = "f(x)";

        //Constructor default
        public Function()
        {
            Value = new PointGraph[QuantilyPoint];
            ActualVector = new Vector();
            CreateFunction();
        }
        //Create point graph
        public void CreateFunction()
        {
            for (int i = 0; i < QuantilyPoint; i++)
            {
                Value[i].Belong = true; //Default each point belong down graph
                Value[i].X = i - 1000;
                Value[i].Y = CalculateValue(i - 1000);
            }
        }
        //Calculate value point function
        public virtual int CalculateValue(int i)
        {
            throw new NotImplementedException(); //Each derived class must have own increment this function 
        }

        //Function calculate absolute value from each point function(point.y = value.y)
        public void AbsoluteValueFunction()
        {
            for (int i = 0; i < QuantilyPoint; i++)
                Value[i].Y = -Math.Abs(Value[i].Y);
            Transform += " -> Absolute value from function";
        }

        //Function move each point about vector    
        public void TransformAboutVector(Vector vector)
        {
            for (int i = 0; i < QuantilyPoint; i++)
            {
                this.Value[i].Y -= vector.Y;
                this.Value[i].X += vector.X;
            }
            Transform += $" -> Vector[{vector.X}, {vector.Y}]";
        }

        //Function transform by symmetry axis x Cartesian [f(x) -Sox-> -f(x)]
        public void SymmetryOX()
        {
            for (int i = 0; i < QuantilyPoint; i++)
                Value[i].Y *= -1;
            Transform += " -> S axis X";
        }

        //Function transform by symmetry axis Y Cartesian [f(x) -Soy-> f(-x)]
        private void swap(PointGraph a, PointGraph b)
        {
            PointGraph c = new PointGraph();
            c = a;
            a = b;
            b = c;
        }
        public void SymmetryOY()
        {
            for (int i = 0; i < QuantilyPoint; i++)
                Value[i].X *= -1;
            for (int i = 0, j = 2000; i != j; i++, j--)
                swap(Value[i], Value[j]);
            Transform += " -> S axis Y";
        }

        //Function transform by symmetry point zero Cartesian [f(x) -S point(0,0)-> -f(-x)]
        public void SymmetryPointZero()
        {
            SymmetryOX();
            SymmetryOY();
        }

        //If argument < 0 -> f(x)=f(Abs(x))

        public void AbsoluteValueArgument()
        {
            int i = 0;
            while (Value[i].X != 0) i++;
            for (int j = i - 1, a = 2; j > 300; j--, a += 2)
            {
                Value[j].Belong = Value[j + a].Belong;
                Value[j].Y = Value[j + a].Y;
            }
            Transform += " -> Absolute value from argument";
        }

        //Power function

        public void PowerFunction(double power)
        {
            for (int i = 0; i < QuantilyPoint; i++)
                Value[i].Y = Convert.ToInt32(Value[i].Y * power);
            FunctionPowerValue = Math.Round(FunctionPowerValue*power, 2);
        }

        //Convert to pattern
        public override string ToString()
        {
            return "f(x)";
        }
    }
}
