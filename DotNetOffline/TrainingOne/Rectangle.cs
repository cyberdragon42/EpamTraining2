using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceClasses;

namespace Enums
{
    public struct Rectangle : ISize, ICoordinates
    {
        private double _width;
        private double _height;
        public double X { get; set; }
        public double Y { get; set; }
        public double Width
        {
            get
            {
                return _width;
            }

            set
            {
                if (value > 0)
                    _width = value;
            }
        }
        public double Height
        {
            get
            {
                return _height;
            }

            set
            {
                if (value > 0)
                    _height = value;
            }
        }
        IPrinter Printer;

        public Rectangle(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Printer = new ConsolePrinter();
            if (width <= 0)
                throw new ArgumentException("Width sould be greater than 0","width");
            _width = width;
            if (height <= 0)
                throw new ArgumentException("Height sould be greater than 0","height");
            _height = height;
        }

        public void Perimeter()
        {
            double perimeter = Width * 2 + Height * 2;
            Printer.Print(perimeter.ToString());
        }
    }
}
