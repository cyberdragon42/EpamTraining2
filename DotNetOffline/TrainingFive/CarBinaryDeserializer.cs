using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Enums;
using ServiceClasses;

namespace Serialization
{
    public class CarBinaryDeserilizer:ICarDeserializer
    {
        IPrinter Printer;
        public List<Car> carsToDeserialize { get; set; }
        public string Path { get; set; }

        public CarBinaryDeserilizer(IPrinter printer)
        {
            try
            {
                Printer = printer;
                Path = ConfigurationSettings.AppSettings["binarySerializationFile"];
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public void Deserialize()
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream fs = new FileStream(Path, FileMode.Open))
                {
                    carsToDeserialize = (List<Car>)bf.Deserialize(fs);
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
