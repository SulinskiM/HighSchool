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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Object down draw function
        Graph Function;

        public MainWindow()
        {
            InitializeComponent();

            //Draw grill and Cartesian
            LineDraw.DrawNet(myGrid);
            LineDraw.DrawCartesian(myGrid);

            Function = new LineFunction();
        }

        private void ZeroOfBox(TextBox box1, TextBox box2)
        {
            box1.Text = "0";
            box2.Text = "0";
        }
        private void ZeroOfBox(TextBox box1, TextBox box2, string Value)
        {
            box1.Text = "0";
            box2.Text = "0";
        }
        private void NullObject(Label label, string value)
        {
            label.Content = value;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Function = new Graph();
        }

        //Transport function about vector
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Function.Vector.X = Convert.ToInt32(VectorX.Text) * 10;
                Function.Vector.Y = Convert.ToInt32(VectorY.Text) * 10;
                Function.ActualVector.Add(Function.Vector);
                if (Function.Vector.X != 0 || Function.Vector.Y != 0)
                    ModificationFunction.Content += " -> Vector [" + VectorX.Text + " , " + VectorY.Text + "]";
                Function.TransformAboutVector();
                Function.DrawGraph(myGrid, 0);
                wzor.Content = "f(x) = " + Function.ToString();
            }
            catch (Exception ex)
            {
                ErrorVector.Content = ex.Message;
            }
            finally
            {
                ZeroOfBox(VectorX, VectorY);
                Function.Vector.NullOfVector();
            }
        }

        //Calculate absolute value function
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Function.AbsoluteValueFunction();
            Function.DrawGraph(myGrid, 1);
            ModificationFunction.Content += " -> |f(x)|";
            PatternFunction();
            wzor.Content = "f(x) = " + Function.ToString();
        }
        private void PatternFunction()
        {
            if (Function.CharSymX == "-")
            {
                Function.LeftSide = "-" + Function.LeftSide;
                Function.CharSymX = "";
                Function.SymX = 1;
            }
            if (Function.ActualVector.Y != 0)
            {
                if (Function.ActualVector.Y < 0)
                    Function.RightSide += Convert.ToString(Function.ActualVector.Y / 10);
                else
                    Function.RightSide += " + " + Convert.ToString(Function.ActualVector.Y / 10);
                Function.ActualVector.Y = 0;
            }
            Function.LeftSide = "|" + Function.LeftSide;
            Function.RightSide += "|";
        }

        //Calculate absolute value with argument
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Function.AbsoluteValueArgument();
            Function.DrawGraph(myGrid, 2);
            ModificationFunction.Content += " -> f(|x|)";
            wzor.Content = "f(x) = " + Function.ToString();
        }

        //Symmetry OX
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Function.SymmetryAsisX();
            Function.DrawGraph(myGrid, 3);
            ModificationFunction.Content += " -> SOX";
            wzor.Content = "f(x) = " + Function.ToString();
        }

        //Symmetry OY
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Function.SymmetryAxisY();
            Function.DrawGraph(myGrid, 4);
            ModificationFunction.Content += " -> SOY";
            wzor.Content = "f(x) = " + Function.ToString();
        }

        //Power function
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            try
            {
                Function.PowerFunction(Convert.ToInt32(PowerFunction.Text));
                Function.DrawGraph(myGrid, 5);
            }
            catch (Exception ex)
            {
                ErrorVector.Content = ex.Message;
            }
            finally
            {
                ZeroOfBox(PowerFunction, BoxK2);
            }
        }

        //Symmetry point(0, 0)
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Function.SymmetryPointZero();
            Function.DrawGraph(myGrid, 6);
            ModificationFunction.Content += " -> S Point(0, 0)";
            wzor.Content = "f(x) = " + Function.ToString();
        }

        //Show value function for x
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            try
            {
                int b = Convert.ToInt32(ShowValue.Text);
                var value =
                    from a in Function.Value
                    where a.X == b * 10
                    select a.Y;
                foreach (var item in value) { ValueFunction.Content = "f(x) = " + Convert.ToString(-item / 10); }
            }
            catch (Exception ex)
            {
                ErrorVector.Content = ex.Message;
            }
        }

        //Clear window
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            
            InitializeComponent();
        }

        //Set up line function
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Function = new LineFunction();
        }

        //Draw graph actualy function
        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            Function.DrawGraph(myGrid, 8);
            wzor.Content = "f(x) = " + Function.ToString();
        }

        //Show position mouse relative point(0, 0)
        private void myGrid2_MouseMove(object sender, MouseEventArgs e)
        {
            ShowMousePosition(e);
        }
        private void ShowMousePosition(MouseEventArgs e)
        {
            try
            {
                Point mouseLocation = e.GetPosition(myGrid);

                if (Math.Round(mouseLocation.X / 10, 2) <= 30 && Math.Round(mouseLocation.Y / 10, 2) <= 30)
                {
                    MouseX.Content = "X = " + Convert.ToString(Math.Round(mouseLocation.X / 10, 2));
                    MouseY.Content = "Y = " + Convert.ToString(-Math.Round(mouseLocation.Y / 10, 2));
                }
                else
                {
                    MouseX.Content = "X = ###";
                    MouseY.Content = "Y = ###";
                }
            }
            catch (Exception ex)
            {
                ErrorVector.Content = ex.Message;
            }
        }
    }
}
