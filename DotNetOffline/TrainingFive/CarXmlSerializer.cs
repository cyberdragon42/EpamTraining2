using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Enums;
using ServiceClasses;

namespace Serialization
{
    public class CarXmlSerializer:ICarSerializer
    {
        #region Fields
        IPrinter Printer;
        public List<Car> CarsToSerialize { get; set; }
        public string Path { get; set; }
        #endregion

        #region Constructors
        public CarXmlSerializer(IPrinter printer)
        {
            Printer = printer;
            CarsToSerialize = new List<Car>();
        }

        public CarXmlSerializer(string path, IPrinter printer)
        {
            Printer = printer;
            CarsToSerialize = new List<Car>();
            Path = path;
        }
        #endregion

        #region Methods
        public void Serialize()
        {
            if (CarsToSerialize.Count > 0)
            {
                //serialize
                XmlSerializer serializer = new XmlSerializer(typeof(Car));
                using (FileStream fs = new FileStream(Path, FileMode.Create))
                {
                    foreach (var car in CarsToSerialize)
                    {
                        serializer.Serialize(fs, car);
                    }
                }
            }
            else
            {
                Printer.Print("Target can't be serialized because the list of cars is emty");
            }
        }
        #endregion
    }
}
