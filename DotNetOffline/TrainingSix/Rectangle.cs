using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleCop
{
    public class Rectangle
    {
        #region Constructors
        public Rectangle(Point a, Point d)
        {
            A = a;
            D = d;
            B = new Point(D.X, A.Y);
            C = new Point(A.X, D.Y);
            //Validation
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
            return new Rectangle(topLeft,bottomRight);
        }

        public Rectangle BuildIntersectRectangle(Rectangle secondRectangle)
        {
            double topLeftX = 0;
            double topLeftY = 0;
            double bottomRightX = 0;
            double bottomRightY = 0;

            if (secondRectangle.A.Y <= A.Y && secondRectangle.A.Y >= C.Y && secondRectangle.A.X <= D.X)
            {
                if (secondRectangle.A.X <= A.X && secondRectangle.B.X <= B.X)
                {
                    topLeftX = C.X;
                    topLeftY = secondRectangle.A.Y;
                    bottomRightX = secondRectangle.B.X;
                    bottomRightY = C.Y;
                }

                if (secondRectangle.A.X <= A.X && secondRectangle.B.X >= B.X)
                {
                    topLeftX = C.X;
                    topLeftY = secondRectangle.A.Y;
                    bottomRightX = D.X;
                    bottomRightY = D.Y;
                }

                if (secondRectangle.A.X >= A.X && secondRectangle.B.X <= B.X)
                {
                    topLeftX = secondRectangle.A.X;
                    topLeftY = secondRectangle.A.Y;
                    bottomRightX = secondRectangle.B.X;
                    bottomRightY = C.Y;
                }

                if (secondRectangle.A.X >= A.X && secondRectangle.B.X >= B.X)
                {
                    topLeftX = secondRectangle.A.X;
                    topLeftY = secondRectangle.A.Y;
                    bottomRightX = D.X;
                    bottomRightY = D.Y;
                }
            }

            else if (secondRectangle.C.Y <= A.Y && secondRectangle.C.Y >= C.Y && secondRectangle.C.X <= D.X)
            {
                if (secondRectangle.C.X >= A.X && secondRectangle.D.X <= D.X)
                {
                    topLeftX = secondRectangle.A.X;
                    topLeftY = A.Y;
                    bottomRightX = secondRectangle.D.X;
                    bottomRightY = secondRectangle.D.Y;
                }

                if (secondRectangle.C.X >= A.X && secondRectangle.D.X >= D.X)
                {
                    topLeftX = secondRectangle.A.X;
                    topLeftY = A.Y;
                    bottomRightX = D.X;
                    bottomRightY = secondRectangle.D.Y;
                }

                if (secondRectangle.C.X <= A.X && secondRectangle.D.X <= D.X)
                {
                    topLeftX = A.X;
                    topLeftY = A.Y;
                    bottomRightX = secondRectangle.D.X;
                    bottomRightY = secondRectangle.D.Y;
                }

                if (secondRectangle.C.X <= A.X && secondRectangle.D.X >= D.X)
                {
                    topLeftX = A.X;
                    topLeftY = A.Y;
                    bottomRightX = D.X;
                    bottomRightY = secondRectangle.D.Y;
                }
            }

            else if (secondRectangle.B.X >= A.X && secondRectangle.B.X <= B.X && secondRectangle.B.Y >= D.Y)
            {
                if (secondRectangle.B.Y >= A.Y && secondRectangle.D.Y >= C.Y)
                {
                    topLeftX = secondRectangle.D.X;
                    topLeftY = A.X;
                    bottomRightX = secondRectangle.D.X;
                    bottomRightY = secondRectangle.D.Y;
                }

                if (secondRectangle.B.Y >= A.Y && secondRectangle.D.Y <= C.Y)
                {
                    topLeftX = secondRectangle.D.X;
                    topLeftY = A.X;
                    bottomRightX = secondRectangle.D.X;
                    bottomRightY = D.Y;
                }

                if (secondRectangle.B.Y <= A.Y && secondRectangle.D.Y >= C.Y)
                {
                    topLeftX = A.X;
                    topLeftY = secondRectangle.A.Y;
                    bottomRightX = secondRectangle.D.X;
                    bottomRightY = secondRectangle.D.Y;
                }

                if (secondRectangle.B.Y <= A.Y && secondRectangle.D.Y <= C.Y)
                {
                    topLeftX = A.X;
                    topLeftY = secondRectangle.A.Y;
                    bottomRightX = secondRectangle.D.X;
                    bottomRightY = D.Y;
                }
            }

            else if (secondRectangle.A.X >= A.X && secondRectangle.A.X <= B.X && secondRectangle.B.Y >= D.Y)
            {
                if (secondRectangle.A.Y >= A.Y && secondRectangle.C.Y <= C.Y)
                {
                    topLeftX = secondRectangle.A.X;
                    topLeftY = A.Y;
                    bottomRightX = D.X;
                    bottomRightY = D.Y;
                }

                if (secondRectangle.A.Y >= A.Y && secondRectangle.C.Y >= C.Y)
                {
                    topLeftX = secondRectangle.A.X;
                    topLeftY = A.Y;
                    bottomRightX = D.X;
                    bottomRightY = secondRectangle.D.Y;
                }

                if (secondRectangle.A.Y <= A.Y && secondRectangle.C.Y >= C.Y)
                {
                    topLeftX = secondRectangle.A.X;
                    topLeftY = secondRectangle.A.Y;
                    bottomRightX = D.X;
                    bottomRightY = secondRectangle.D.Y;
                }

                if (secondRectangle.A.Y <= A.Y && secondRectangle.C.Y <= C.Y)
                {
                    topLeftX = secondRectangle.A.X;
                    topLeftY = secondRectangle.A.Y;
                    bottomRightX = D.X;
                    bottomRightY = D.Y;
                }
            }
            else
                throw new ArgumentException("Rectangles don't intersect");
            Point topLeft = new Point(topLeftX, topLeftY);
            Point bottomRight = new Point(bottomRightX, bottomRightY);
            return new Rectangle(topLeft, bottomRight);
        }

        #endregion
    }
}
