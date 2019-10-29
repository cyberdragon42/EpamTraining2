using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceClasses;

namespace Serialization
{
    public interface ICarDeserializer
    {
        List<Car> carsToDeserialize { get; set; }
        string Path { get; set; }
        void Deserialize();
    }
}
