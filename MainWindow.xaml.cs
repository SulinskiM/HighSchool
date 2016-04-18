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
        Graph asf;
        public MainWindow()
        {
            InitializeComponent();
            // Add a Line Element

            LineDraw.DrawNet(myGrid);
            LineDraw.DrawCartesian(myGrid);
            //Point[] ad = new Point[200];
            //for(int i=0; i<200; i++)
            //{
            //    int u = i - 100;
            //    ad[i].X = u;
            //    ad[i].Y = -u*u/10;
            //}

            //for (int i = 1; i < 200; i++)
            //{
            //    Line myLine;
            //    myLine = new Line();
            //    myLine.Stroke = System.Windows.Media.Brushes.Red;
            //    myLine.X1 = ad[i].X+250;
            //    myLine.X2 = ad[i-1].X+250;
            //    myLine.Y1 = ad[i].Y+250;
            //    myLine.Y2 = ad[i-1].Y+250;
            //    myLine.HorizontalAlignment = HorizontalAlignment.Left;
            //    myLine.VerticalAlignment = VerticalAlignment.Center;
            //    myLine.StrokeThickness = 2;
            //    myGrid.Children.Add(myLine);
            //}

            asf=new Graph();

            asf.DrawGraph(myGrid);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                asf.Vector.X += Convert.ToInt32(VectorX.Text)*10;
                asf.Vector.Y = Convert.ToInt32(VectorY.Text)*10;
            }
            catch(Exception ex)
            {

            }
            finally
            {
                VectorX.Text = "0";
                VectorY.Text = "0";
            }
            asf.TransformAboutVector();
                asf.DrawGraph(myGrid);
            VectorX.Text = "0";
            VectorY.Text = "0";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            asf.AbsoluteValueFunction();
            asf.DrawGraph(myGrid);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            asf.AbsoluteValueArgument();
            asf.DrawGraph1(myGrid);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            asf.SymmetryAsisX();
            asf.DrawGraph(myGrid);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            asf.SymmetryAxisY();
            asf.DrawGraph(myGrid);
        }
    }
}
