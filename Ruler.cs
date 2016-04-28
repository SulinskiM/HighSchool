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
    abstract class Ruler
    {
        private static void DrawLine(Canvas myGrid, int x1, int x2, int y1, int y2, int i)
        {
            Line myLine = new Line();
            switch (i)
            {
                case 0: myLine.Stroke = System.Windows.Media.Brushes.Black; myLine.StrokeThickness = 1; break;
                case 1: myLine.Stroke = System.Windows.Media.Brushes.DarkBlue; myLine.StrokeThickness = 2; break;
            }
            myLine.X1 = x1;
            myLine.X2 = x2;
            myLine.Y1 = y1;
            myLine.Y2 = y2;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myGrid.Children.Add(myLine);
        }
        public static void DrawCartesian(Canvas grid)
        {
            DrawLine(grid, 0, 0, -290, 290, 1);
            DrawLine(grid, -290, 290, 0, 0, 1);
            DrawLine(grid, 0, -10, -290, -280, 1);
            DrawLine(grid, 10, 0, -280, -290, 1);
            DrawLine(grid, 280, 290, -10, 0, 1);
            DrawLine(grid, 290, 280, 0, 10, 1);
        }
        public static void DrawNet(Canvas grid)
        {
            for (int i = -60; i <= 60; i++)
            {
                DrawLine(grid, -700, 700, i * 10, i * 10, 0);
                DrawLine(grid, i * 10, i * 10, -700, 700, 0);
            }
            DrawLine(grid, 300, 300, -300, 300, 0);
        }
    }
}
