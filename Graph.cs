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
    class Graph : Function
    {
        private Line myLine;

        public Graph()
            : base()
        {
            myLine = new Line();
        }
        private void DrawLine(Canvas myGrid, int i, int color)
        {
            myLine = new Line();
            myLine.Stroke = System.Windows.Media.Brushes.Olive;
            switch (color)
            {
                case 0: myLine.Stroke = System.Windows.Media.Brushes.DarkRed; break;
                case 1: myLine.Stroke = System.Windows.Media.Brushes.DarkOrange; break;
                case 2: myLine.Stroke = System.Windows.Media.Brushes.DarkViolet; break;
                case 3: myLine.Stroke = System.Windows.Media.Brushes.DarkGreen; break;
                case 4: myLine.Stroke = System.Windows.Media.Brushes.Yellow; break;
                case 5: myLine.Stroke = System.Windows.Media.Brushes.Tomato; break;
                case 6: myLine.Stroke = System.Windows.Media.Brushes.Purple; break;
                case 7: myLine.Stroke = System.Windows.Media.Brushes.RoyalBlue; break;
            }
            myLine.X1 = Value[i+1000].X;
            myLine.X2 = Value[i+999].X;
            myLine.Y1 = Value[i+1000].Y;
            myLine.Y2 = Value[i+999].Y;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 2;
            myGrid.Children.Add(myLine);
        }
        public virtual void DrawGraph(Canvas myGrid, int color)
        {
            for (int i = -999; i <=1000; i++)
                //if (FieldFunction[i+1000])
                    //if(Value[i-1]>-250)
                        DrawLine(myGrid, i, color);
        }
    }
}
