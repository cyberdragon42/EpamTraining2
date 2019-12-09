using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using ServiceClasses;
using System.Configuration;

namespace TrainingSerialization
{
    public class CarXmlSerializer : ICarSerializer
    {
        #region Fields
        IPrinter Printer;
        public List<Car> CarsToSerialize { get; set; }
        public string Path { get; set; }
        #endregion

        #region Constructors
        public CarXmlSerializer(IPrinter printer)
        {
            try
            {
                Printer = printer;
                CarsToSerialize = new List<Car>();
                Path = ConfigurationSettings.AppSettings["xmlSerializationFile"];
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region Methods
        public void Serialize()
        {
            if (CarsToSerialize.Count > 0)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));
                //serialize
                using (FileStream fs = new FileStream(Path, FileMode.Create))
                {
                    serializer.Serialize(fs, CarsToSerialize);
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
