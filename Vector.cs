using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector()
        {
            this.X = 0;
            this.Y = 0;
        }
        public Vector(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public Vector(Vector vector)
        {
            this.X = vector.X;
            this.Y = vector.Y;
        }
        public void NullOfVector()
        {
            this.X = 0;
            this.Y = 0;
        }
        public void Add(Vector vector)
        {
            this.X += vector.X;
            this.Y += vector.Y;
        }
        public void MultiplyVectorY(int i)
        {
            this.Y *= i;
        }
        public void MultiplyVectorX(int v)
        {
            this.X *= v;
        }
    }
}
