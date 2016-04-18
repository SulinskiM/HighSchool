using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;


namespace WpfApplication1
{
    abstract class LineDraw
    {
        private static void DrawLine(Canvas myGrid, int x1, int x2, int y1, int y2)
        {
            Line line = new Line();
            line.Stroke = System.Windows.Media.Brushes.DarkBlue;
            line.X1 = x1;
            line.X2 = x2;
            line.Y1 = y1;
            line.Y2 = y2;
            line.HorizontalAlignment = HorizontalAlignment.Left;
            line.VerticalAlignment = VerticalAlignment.Center;
            line.StrokeThickness = 4;
            myGrid.Children.Add(line);
        }
        public static void DrawCartesian(Canvas grid)
        {
            DrawLine(grid, 250, 250, 10, 490);
            DrawLine(grid, 10, 490, 250, 250);
            DrawLine(grid, 240, 250, 20, 10);
            DrawLine(grid, 250, 260, 10, 20);
            DrawLine(grid, 480, 490, 240, 250);
            DrawLine(grid, 490, 480, 250, 260);
        }
        public static void DrawNet(Canvas grid)
        {
            for (int i = 0; i < 50; i++)
            {
                DrawLineNet(grid, 0, 500, i*10, i*10);
                DrawLineNet(grid, i * 10, i * 10, 0,500);
            }
        }
        private static void DrawLineNet(Canvas myGrid, int x1, int x2,int y1,int y2)
        {
            Line myLine = new Line();
            myLine.Stroke = System.Windows.Media.Brushes.Black;
            myLine.X1 = x1;
            myLine.X2 = x2;
            myLine.Y1 = y1;
            myLine.Y2 = y2;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 1;
            myGrid.Children.Add(myLine);
        }
    }
}
