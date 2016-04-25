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
                case 4: myLine.Stroke = System.Windows.Media.Brushes.Indigo; break;
                case 5: myLine.Stroke = System.Windows.Media.Brushes.Tomato; break;
                case 6: myLine.Stroke = System.Windows.Media.Brushes.Purple; break;
                case 7: myLine.Stroke = System.Windows.Media.Brushes.RoyalBlue; break;
                case 8: myLine.Stroke = System.Windows.Media.Brushes.Black; break;
            }
            myLine.X1 = Value[i].X;
            myLine.X2 = Value[i-1].X;
            myLine.Y1 = Value[i].Y;
            myLine.Y2 = Value[i-1].Y;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 2;
            myGrid.Children.Add(myLine);
        }
        public virtual void DrawGraph(Canvas myGrid, int color)
        {
            for (int i = 1; i <=2000; i++)
                if (FieldFunction[i])
                        DrawLine(myGrid, i, color);
        }
    }
}
