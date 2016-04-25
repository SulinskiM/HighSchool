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
    class Function
    {
        public bool[] FieldFunction;
        public Point[] Value;
        private const int SCALEGRAPH = 10;
        public Vector Vector { get; set; }
        public Vector ActualVector { get; set; }
        public int SymY { get; set; }
        public int SymX { get; set; }
        public int AbsX { get; set; }
        public string PatternFunction;
        public string LeftSide;
        public string RightSide;
        public string CharSymX;
        public string CharSymY;
        public string CharAbsX;
        public bool Sy;

        public Function()
        {
            FieldFunction = new bool[2001];
            for (int i = 0; i <= 2000; i++)
                FieldFunction[i] = true;
            Value = new Point[2001];
            ChargeValue();
            Vector = new Vector();
            ActualVector = new Vector();
            PatternFunction = "x";
            SymY = 1;
            SymX = 1;
            AbsX = 1;
            Sy = true;
        }

        //Calculate value function for x (f(x))
        public virtual int CountValue(int i)
        {
            return -i * i / SCALEGRAPH;
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
            for (int i = -1000; i <= 1000; i++)
            {
                this.Value[i + 1000].Y -= this.Vector.Y;
                this.Value[i + 1000].X -= this.Vector.X;
            }
            this.Vector.NullOfVector();
        }

        //Symmetry through the axis X

        public void SymmetryAsisX()
        {
            for (int i = -1000; i <= 1000; i++) this.Value[i + 1000].Y = -this.Value[i + 1000].Y;
            SymX *= -1;
            ActualVector.MultiplyVectorY(-1);
        }

        //Symmetry through the axis Y

        public void SymmetryAxisY()
        {
            for (int i = -1000; i <= 1000; i++) Value[i + 1000].X *= -1;
            if(Sy==true)
            ActualVector.MultiplyVectorX(-1);
            SymY *= -1;
            Sy = false;
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
            for (int i = -1000; i <= 1000; i++)
            {
                this.Value[i + 1000].Y = -Math.Abs(this.Value[i + 1000].Y);
            }
        }

        //The absolute value of argument (f(|x|))

        public void AbsoluteValueArgument()
        {
            int i = 0;
            while (Value[i].X != 0) { i++; }

            int a = 2;
            for (int j = i - 1; j > 300; j--)
            {
                Value[j].Y = Value[j + a].Y;
                a += 2;
            }
            AbsX *= -1;
            SymY = 1;
        }

        //k*f(x)

        public void PowerFunction(int k)
        {
            for (int i = -1000; i < 1000; i++)
                Value[i + 1000].Y *= k;
        }

        //f(k*x)

        public void PowerArgument(int k)
        {

        }

        public override string ToString()
        {
            if (SymX == -1) CharSymX = "-"; else CharSymX = "";
            if (SymY == -1) CharSymY = "-"; else CharSymY = "";
            if (AbsX == -1) CharAbsX = "|"; else CharAbsX = "";
            if (ActualVector.X != 0)
            {
                if (ActualVector.X < 0)
                    PatternFunction = "(" + CharSymY + "x" + Convert.ToString(ActualVector.X / 10) + ")*(" + CharSymY + "x" + Convert.ToString(ActualVector.X / 10) + ")";
                else
                {
                    if (ActualVector.X > 0)
                        PatternFunction = "(" + CharSymY + "x+" + Convert.ToString(ActualVector.X / 10) + ")*(" + CharSymY + "x+" + Convert.ToString(ActualVector.X / 10) + ")";
                }
            }
            else
                PatternFunction = "(" + CharSymY + CharAbsX+"x"+CharAbsX+")*(" + CharSymY +CharAbsX+ "x"+CharAbsX+")";
            if (ActualVector.Y != 0)
            {
                if (ActualVector.Y > 0)
                    return CharSymX + LeftSide + PatternFunction + RightSide + "+" + Convert.ToString(ActualVector.Y / 10);
                else
                    return CharSymX + LeftSide + PatternFunction + RightSide + Convert.ToString(ActualVector.Y / 10);
            }
            else
                return CharSymX + LeftSide + PatternFunction + RightSide;
        }
    }
}
