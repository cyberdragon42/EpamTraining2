using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Serialization
{
    public class CarJsonDeserializer:ICarDeserializer
    {
        public List<Car> carsToDeserialize { get; set; }
        public string Path { get; set; }

        public void Deserialize()
        {
            using (StreamReader sr = new StreamReader(Path))
            {
                while (!sr.EndOfStream)
                {
                    string stringCar = sr.ReadLine();
                    Car restortedCar = JsonSerializer.Deserialize<Car>(stringCar);
                    carsToDeserialize.Add(restortedCar);
                }
            }
        }
    }
}