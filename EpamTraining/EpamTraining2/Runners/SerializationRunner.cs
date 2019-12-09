using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceClasses;
using TrainingSerialization;

namespace EpamTraining2
{
    public class SerializationRunner: IRunner
    {
        ILogger Logger;
        List<Car> _carsToSerialize;

        public SerializationRunner()
        {
            Logger = new TextFileLogger();
            _carsToSerialize = new List<Car>()
            {
                new Car(1,100000,7,500),
                new Car(2,150000,4,550),
                new Car(3,780000,6,720),
                new Car(4,200000,8,321),
                new Car(5,220000,2,440),
            };
        }
        public void Run()
        {
            try
            {
                RunTaskBinary();
                RunTaskJson();
                RunTaskXml();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Logger.Log(e.Message);
            }
        }

        public void RunTaskBinary()
        {
            Console.WriteLine("____________Task Binary Serialization____________");
            Console.WriteLine("Binary serialization:");
            CarBinarySerializer carBinarySerializer = new CarBinarySerializer(new ConsolePrinter());
            carBinarySerializer.CarsToSerialize = _carsToSerialize;
            carBinarySerializer.Serialize();
            Console.WriteLine("Binary deserialization:");
            CarBinaryDeserilizer carBinaryDeserilizer = new CarBinaryDeserilizer(new ConsolePrinter());
            carBinaryDeserilizer.Deserialize();
        }

        public void RunTaskXml()
        {
            Console.WriteLine("____________Task Xml Serialization____________");
            Console.WriteLine("Xml serialization:");
            CarXmlSerializer carXmlSerializer = new CarXmlSerializer(new ConsolePrinter());
            carXmlSerializer.CarsToSerialize = _carsToSerialize;
            carXmlSerializer.Serialize();
            Console.WriteLine("Xml deserialization:");
            CarXmlDeserializer carXmlDeserializer = new CarXmlDeserializer(new ConsolePrinter());
            carXmlDeserializer.Deserialize();
        }

        public void RunTaskJson()
        {
            Console.WriteLine("____________Task Json Serialization____________");
            Console.WriteLine("Json serialization:");
            CarJsonSerializer carJsonSerializer = new CarJsonSerializer(new ConsolePrinter());
            carJsonSerializer.CarsToSerialize = _carsToSerialize;
            carJsonSerializer.Serialize();
            Console.WriteLine("Json deserialization:");
            CarJsonDeserializer carJsonDeserializer = new CarJsonDeserializer(new ConsolePrinter());
            carJsonDeserializer.Deserialize();
        }
    }
}
