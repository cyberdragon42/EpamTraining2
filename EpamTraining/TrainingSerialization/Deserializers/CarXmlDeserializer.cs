using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ServiceClasses;

namespace TrainingSerialization
{
    public class CarXmlDeserializer : ICarDeserializer
    {
        #region Fields
        IPrinter Printer;
        public List<Car> carsToDeserialize { get; set; }
        public string Path { get; set; }
        #endregion

        #region Costructors
        public CarXmlDeserializer(IPrinter printer)
        {
            try
            {
                Printer = printer;
                Path = ConfigurationSettings.AppSettings["xmlSerializationFile"];
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

        #region Methods
        public void Deserialize()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));
                using (FileStream fs = new FileStream(Path, FileMode.Open))
                {
                    carsToDeserialize = (List<Car>)serializer.Deserialize(fs);
                }
                foreach (var car in carsToDeserialize)
                {
                    Printer.Print(car.DisplayCar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        #endregion
    }
}
