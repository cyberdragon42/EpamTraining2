using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleCop
{ 
    public struct Point
    {
        public Point(double x,double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; set; }
        public double Y { get; set; }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point { X = p1.X + p2.X, Y = p1.Y + p2.Y };
        }

        public static Point operator -(Point p1, Point p2)
        {
            return new Point { X = p1.X - p2.X, Y = p1.Y - p2.Y };
        }

    }
}
