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
        LineFunction Function;
        public MainWindow()
        {
            InitializeComponent();
            // Add a Line Element

            LineDraw.DrawNet(myGrid);
            LineDraw.DrawCartesian(myGrid);

            Function = new LineFunction();

            Function.DrawGraph(myGrid, 7);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Function.Vector.X = Convert.ToInt32(VectorX.Text) * 10;
                Function.Vector.Y = Convert.ToInt32(VectorY.Text) * 10;
                ModificationFunction.Content = Function.ToString();
                Function.TransformAboutVector();
                Function.DrawGraph(myGrid, 0);
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Function.AbsoluteValueFunction();
            Function.DrawGraph(myGrid,1);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Function.AbsoluteValueArgument();
            Function.DrawGraph(myGrid,2);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Function.SymmetryAsisX();
            Function.DrawGraph(myGrid, 3);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Function.SymmetryAxisY();
            Function.DrawGraph(myGrid,4);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            try
            {
                Function.KF(Convert.ToDouble(BoxK.Text));
                Function.DrawGraph(myGrid,5);
            }
            catch (Exception ex)
            {
                ErrorVector.Content = ex.Message;
            }
            finally
            {
                ZeroOfBox(BoxK, BoxK2);
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Function.SymmetryPointZero();
            Function.DrawGraph(myGrid,6);
        }


        private void myGrid2_MouseMove(object sender, MouseEventArgs e)
        {
            Point mouseLocation = e.GetPosition(myGrid);

            if (Math.Round(mouseLocation.X / 10, 2) <= 30)
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
            catch(Exception ex)
            {
                ErrorVector.Content = ex.Message;
            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            LineDraw.DrawNet(myGrid);
            LineDraw.DrawCartesian(myGrid);
        }
    }
}
