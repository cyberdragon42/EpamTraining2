using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceClasses;

namespace TrainingStyleCop
{
    public class Rectangle
    {
        public IPrinter Printer = new ConsolePrinter();
        #region Constructors
        public Rectangle(Point a, Point d)
        {
            A = a;
            D = d;
            B = new Point(D.X, A.Y);
            C = new Point(A.X, D.Y);

            if (A.X >= D.X || A.Y <= D.Y)
                throw new ArgumentException("Rectangle can't be created");
        }
        #endregion

        #region Properties
        public Point A { get; private set; }
        public Point B { get; private set; }
        public Point C { get; private set; }
        public Point D { get; private set; }
        #endregion

        #region Methods
        public void Move(Point distance)
        {
            A = A + distance;
            B = B + distance;
            C = C + distance;
            D = D + distance;
        }

        public void Resize(double difference)
        {
            A = A + new Point(difference / -2, difference / 2);
            B = B + new Point(difference / 2, difference / 2);
            C = C + new Point(difference / -2, difference / -2);
            D = D + new Point(difference / 2, difference / -2);
        }

        public Rectangle BuildUnionRectangle(Rectangle secondRectangle)
        {
            double topLeftX = A.X < secondRectangle.A.X ? A.X : secondRectangle.A.X;
            double topLeftY = A.Y > secondRectangle.A.Y ? A.Y : secondRectangle.A.Y;
            Point topLeft = new Point(topLeftX, topLeftY);
            double bottomRightX = D.X > secondRectangle.D.X ? D.X : secondRectangle.D.X;
            double bottomRightY = D.Y < secondRectangle.D.Y ? D.Y : secondRectangle.D.Y;
            Point bottomRight = new Point(bottomRightX, bottomRightY);
            return new Rectangle(topLeft, bottomRight);
        }

        public void ShowRectangle(Rectangle rectangle)
        {
            Printer.Print(String.Format("A: ({0},{1}); D: ({2},{3})",rectangle.A.X, rectangle.A.Y, rectangle.D.X, rectangle.D.Y));
        }

        #endregion
    }
}
