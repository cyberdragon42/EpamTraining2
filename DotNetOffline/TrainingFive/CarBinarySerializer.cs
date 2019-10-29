using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Enums;
using ServiceClasses;

namespace Serialization
{
    public class CarBinarySerializer:ICarSerializer
    {
        #region Fields
        IPrinter Printer;
        public List<Car> CarsToSerialize { get; set; }
        public string Path { get; set; }
        #endregion

        #region Constructors
        public CarBinarySerializer()
        {
            Printer = new ConsolePrinter();
            CarsToSerialize = new List<Car>();
        }

        public CarBinarySerializer(string path)
        {
            Printer = new ConsolePrinter();
            CarsToSerialize = new List<Car>();
            Path = path;
        }
        #endregion

        #region Methods
        public void Serialize()
        {
            if (CarsToSerialize.Count > 0)
            {
                //serialize
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
                {
                    foreach (var car in CarsToSerialize)
                    {
                        bf.Serialize(fs, car);
                    }
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
