using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApplication1
{
    struct Point1
    {
        Point Point;
        bool FieldFunction;
    }
    class Function
    {
        public bool[] FieldFunction;
        public Point[] Value;
        private const int SCALEGRAPH = 10;
        public Vector Vector { get; set; }
        public int SymY { get; set; } = -1;

        public Function()
        {
            FieldFunction = new bool[2001];
            for (int i = 0; i <= 2000; i++)
                FieldFunction[i] = true;
            Value = new Point[2001];
            ChargeValue();
            Vector = new Vector();
        }

        //Calculate value function for x (f(x))
        public virtual int CountValue(int i)
        {
            return -i*i /SCALEGRAPH;
        }
        private void ChargeValue()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                if (FieldFunction[i + 1000])
                {
                    Value[i + 1000].X = i;
                    Value[i + 1000].Y = CountValue(i);
                }
            }
        }

        //TODO: Modifity function:


        //Transform about vector

        public void TransformAboutVector()
        {
            for(int i=-1000; i<=1000; i++)
            {
                this.Value[i + 1000].Y -= this.Vector.Y;
                this.Value[i + 1000].X -= this.Vector.X;
            }
            this.Vector.Y = 0;
            this.Vector.X = 0;
        }

        //Symmetry through the axis X

        public void SymmetryAsisX()
        {
            for (int i = -1000; i <= 1000; i++)
            {
                this.Value[i+1000].Y = -this.Value[i+1000].Y;  
            }
        }

        //Symmetry through the axis Y

        public void SymmetryAxisY()
        {
            for(int i=-1000; i<=1000; i++)
            {
                Value[i + 1000].X *= -1;
            }
        }

        //Symmetry through the point (0,0)

        public void SymmetryPointZero()
        {
            SymmetryAsisX();
            SymmetryAxisY();
        }

        //The absolute value of function (|f(x)|)

        public void AbsoluteValueFunction()
        {
            for(int i=-1000; i<=1000; i++)
            {
                this.Value[i+1000].Y = -Math.Abs(this.Value[i+1000].Y);
            }
        }

        //The absolute value of argument (f(|x|))

        public void AbsoluteValueArgument()
        {
            int i = 0;
            while (Value[i].X != 0) { i++; }
           
            int a = 2;
            for(int j= i-1; j>300; j--)
            {
                Value[j].Y = Value[j + a].Y;
                a += 2;
            }
        }

        //k*f(x)

        public void KF(double k)
        {
            for (int i = -1000; i < 1000; i++)
                Value[i+1000].Y *= Convert.ToInt32(k);
        }

        //f(k*x)
        public override string ToString()
        {
            return "f(x"+Convert.ToString(Vector.X) +")";
        }
    }
}
