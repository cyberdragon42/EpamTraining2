using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Enums;
using ServiceClasses;

namespace Serialization
{
    public class CarXmlDeserializer:ICarDeserializer
    {
        #region Fields
        IPrinter Printer;
        public List<Car> carsToDeserialize { get; set; }
        public string Path { get; set; }
        #endregion

        #region Costructors
        public CarXmlDeserializer()
        {
            Printer = new ConsolePrinter();
        }

        public CarXmlDeserializer(string path)
        {
            Printer = new ConsolePrinter();
            Path = path;
        }
        #endregion

        #region Methods
        public void Deserialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Car));
            using (FileStream fs = new FileStream(Path, FileMode.Open))
            {
                carsToDeserialize = (List<Car>)serializer.Deserialize(fs);
            }
        }

        public void DisplayDeserializedCars()
        {
            if(carsToDeserialize.Count>0)
            {
                foreach(var car in carsToDeserialize)
                {

                }
            }
        }

        #endregion
    }
}
