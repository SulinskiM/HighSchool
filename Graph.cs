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
        private const int POSITIONZEROPOINT = 250;

        public Graph()
            : base()
        {
            myLine = new Line();
        }
        private void DrawLine(Canvas myGrid, int i)
        {
            myLine = new Line();
            myLine.Stroke = System.Windows.Media.Brushes.DarkRed;
            myLine.X1 = i -this.Vector.X;
            myLine.X2 = i -this.Vector.X;
            myLine.Y1 = Value[i] + POSITIONZEROPOINT;
            myLine.Y2 = Value[i-1] + POSITIONZEROPOINT;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 2;
            myGrid.Children.Add(myLine);
        }
        private void DrawLine1(Canvas myGrid, int i)
        {
            myLine = new Line();
            myLine.Stroke = System.Windows.Media.Brushes.White;
            myLine.X1 = SymY*i - this.Vector.X;
            myLine.X2 = SymY*i - this.Vector.X;
            myLine.Y1 = Value[i] + POSITIONZEROPOINT;
            myLine.Y2 = Value[i - 1] + POSITIONZEROPOINT;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 2;
            myGrid.Children.Add(myLine);
        }
        public virtual void DrawGraph(Canvas myGrid)
        {
            for (int i = 1; i <=500; i++)
                if (FieldFunction[i])
                    //if(Value[i-1]>-250)
                        DrawLine(myGrid, i);
        }
        public virtual void DrawGraph1(Canvas myGrid)
        {
            for (int i = 1; i <= 500; i++)
                if (FieldFunction[i])
                    //if(Value[i-1]>-250)
                    DrawLine1(myGrid, i);
        }
    }
}
