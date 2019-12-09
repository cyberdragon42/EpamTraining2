using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceClasses;
using System.Text.Json;

namespace TrainingSerialization
{
    public class CarJsonDeserializer : ICarDeserializer
    {
        IPrinter Printer;
        public List<Car> carsToDeserialize { get; set; }
        public string Path { get; set; }

        public CarJsonDeserializer(IPrinter printer)
        {
            Printer = printer;
            carsToDeserialize = new List<Car>();
            try
            {
                Path = ConfigurationSettings.AppSettings["jsonSerializationFile"];
            }
            catch (Exception e)
            {
                Printer.Print(e.Message);
            }
        }

        public void Deserialize()
        {
            using (StreamReader sr = new StreamReader(Path))
            {
                string stringCars = sr.ReadToEnd();
                carsToDeserialize = JsonSerializer.Deserialize<List<Car>>(stringCars);
            }
        }
    }
}
