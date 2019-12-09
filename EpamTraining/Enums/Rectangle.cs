using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceClasses;

namespace TrainingEnums
{
    public struct Rectangle : ISize, ICoordinates
    {
        private double _width;
        private double _height;
       
        public Rectangle(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            if (width <= 0)
                throw new ArgumentException("Width sould be greater than 0", "width");
            _width = width;
            if (height <= 0)
                throw new ArgumentException("Height sould be greater than 0", "height");
            _height = height;
        }

        #region Properties
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

        #endregion
        public double Perimeter()
        {
             return Width * 2 + Height * 2;
        }
    }
}
