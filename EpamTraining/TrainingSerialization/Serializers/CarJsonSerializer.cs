using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Configuration;
using ServiceClasses;

namespace TrainingSerialization
{
    public class CarJsonSerializer : ICarSerializer
    {
        IPrinter Printer;
        public List<Car> CarsToSerialize { get; set; }
        public string Path { get; set; }

        public CarJsonSerializer(IPrinter printer)
        {
            try
            {
                CarsToSerialize = new List<Car>();
                Printer = printer;
                Path = ConfigurationSettings.AppSettings["jsonSerializationFile"];
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Serialize()
        {
            if (CarsToSerialize.Count > 0)
            {
                //serialize
                using (StreamWriter sw = new StreamWriter(Path, false, System.Text.Encoding.Default))
                {
                    string json = JsonSerializer.Serialize<List<Car>>(CarsToSerialize);
                    sw.WriteLine(json);
                }
            }
            else
            {
                Printer.Print("Target can't be serialized because the list of cars is emty");
            }
        }
    }
}
