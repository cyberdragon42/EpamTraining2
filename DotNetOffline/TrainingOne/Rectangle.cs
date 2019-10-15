using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingOne
{
    public struct Rectangle : ISize, ICoordinates
    {
        private double _width;
        private double _heigh;
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
        public double Heigh
        {
            get
            {
                return _heigh;
            }

            set
            {
                if (value > 0)
                    _heigh = value;
            }
        }
        IPrinter Printer;

        public Rectangle(double x, double y, double width, double heigh)
        {
            X = x;
            Y = y;
            _width = width;
            _heigh = heigh;
            Printer = new ConsolePrinter();
        }

        public void Perimeter()
        {
            double perimeter = Width * 2 + Heigh * 2;
            Printer.Print(perimeter.ToString());
        }
    }
}
