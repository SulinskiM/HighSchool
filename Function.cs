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
        public int[] Value;
        private const int SCALEGRAPH = 10;
        public Vector Vector { get; set; }
        public int SymY { get; set; } = 1;

        public Function()
        {
            FieldFunction = new bool[501];
            for (int i = 0; i <= 500; i++)
                FieldFunction[i] = true;
            Value = new int[501];
            ChargeValue();
            Vector = new Vector();
        }

        //Calculate value function for x (f(x))
        protected virtual int CountValue(int i)
        {
            return -i *i /SCALEGRAPH;
        }
        private void ChargeValue()
        {
            for (int i = -250; i <= 250; i++)
            {
                if (FieldFunction[i + 250])
                {
                    Value[i + 250] = CountValue(i);
                }
            }
        }

        //TODO: Modifity function:


        //Transform about vector

        public void TransformAboutVector()
        {
            for(int i=0; i<=500; i++)
            {
                this.Value[i] -= this.Vector.Y;
            }
            this.Vector.Y = 0;
        }

        //Symmetry through the axis X

        public void SymmetryAsisX()
        {
            for (int i = 0; i <= 500; i++)
            {
                this.Value[i] = -this.Value[i];
            }
        }

        //Symmetry through the axis Y
        
        public void SymmetryAxisY()
        {
            SymY *= -1;
        }

        //Symmetry through the point (0,0)

        //The absolute value of function (|f(x)|)

        public void AbsoluteValueFunction()
        {
            for(int i=0; i<=500; i++)
            {
                this.Value[i] = -Math.Abs(this.Value[i]);
            }
        }

        //The absolute value of argument (f(|x|))

        public void AbsoluteValueArgument()
        {
            //int a = 251;
            
            //for (int i = 249;  i>0; i--)
            //{
            //    this.Value[i] = 100;//this.Value[a];
            //    a++;
            //}
        }

        //k*f(x)

        //f(k*x)
    }
}
