using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ServiceClasses;
using System.Configuration;

namespace TrainingSerialization
{
    public class CarBinarySerializer : ICarSerializer
    {
        #region Fields
        IPrinter Printer;
        public List<Car> CarsToSerialize { get; set; }
        public string Path { get; set; }
        #endregion

        #region Constructors
        public CarBinarySerializer(IPrinter printer)
        {
            Printer = printer;
            CarsToSerialize = new List<Car>();
            try
            {
                Path = ConfigurationSettings.AppSettings["binarySerializationFile"];
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region Methods
        public void Serialize()
        {
            if (CarsToSerialize.Count > 0)
            {
                //serialize
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
                    {
                            bf.Serialize(fs, CarsToSerialize);
                    }
                }
                catch (Exception e)
                {
                    throw e;
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
