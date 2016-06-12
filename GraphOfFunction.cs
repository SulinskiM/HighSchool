using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Graph
{
    class GraphOfFunction : Function
    {
        public Line myLine;
        private static int Color = 0;
        public int TypeFunction { get; set; }

        public GraphOfFunction()
            : base()
        {
            myLine = new Line();
        }

        private void DrawLine(Canvas myGrid, int i, int color)
        {
            myLine = new Line();
            myLine.Stroke = System.Windows.Media.Brushes.Olive;
            switch (Color)
            {
                case 0: myLine.Stroke = System.Windows.Media.Brushes.White; break;
                case 1: myLine.Stroke = System.Windows.Media.Brushes.DarkBlue; break;
                case 2: myLine.Stroke = System.Windows.Media.Brushes.Orange; break;
                case 3: myLine.Stroke = System.Windows.Media.Brushes.Blue; break;
                case 4: myLine.Stroke = System.Windows.Media.Brushes.DarkOrange; break;
                case 5: myLine.Stroke = System.Windows.Media.Brushes.Lime; break;
                case 6: myLine.Stroke = System.Windows.Media.Brushes.Yellow; break;
                case 7: myLine.Stroke = System.Windows.Media.Brushes.Red; break;
                case 8: myLine.Stroke = System.Windows.Media.Brushes.Silver; break;
            }
            myLine.X1 = Value[i].X;
            myLine.X2 = Value[i - 1].X;
            myLine.Y1 = Value[i].Y;
            myLine.Y2 = Value[i - 1].Y;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 2;
            myGrid.Children.Add(myLine);
        }
        public virtual void DrawGraph(Canvas myGrid, int color)
        {
            for (int i = 1; i <= 2000; i++)
                if (Value[i-1].Belong)
                    DrawLine(myGrid, i, color);
            if (Color <= 18) Color += 1; else Color = 0;
        }
    }
}
