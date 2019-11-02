using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;


namespace Serialization
{
    public class CarJsonSerializer:ICarSerializer
    {
        public List<Car> CarsToSerialize { get; set; }
        public string Path { get; set; }

        public CarJsonSerializer()
        {
            CarsToSerialize = new List<Car>();
        }

        public CarJsonSerializer(string path)
        {
            CarsToSerialize = new List<Car>();
            Path = path;
        }

        public void Serialize()
        {
            if (CarsToSerialize.Count > 0)
            {
                //serialize
                using (StreamWriter sw = new StreamWriter(Path, false, System.Text.Encoding.Default))
                {
                    foreach (var car in CarsToSerialize)
                    {
                        string json = JsonSerializer.Serialize<Car>(car);
                        sw.WriteLine(json);
                    }
                }
            }
        }
    }
}

