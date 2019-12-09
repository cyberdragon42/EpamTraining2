using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingEnums;
using ServiceClasses;
using TrainingDirectories;
using TrainingCalculator;
using TrainingReflection;
using TrainingStyleCop;
using TrainingSerialization;
using TrainingThreads;

namespace EpamTraining2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRunner> runners = new List<IRunner>()
            {
                new SerializationRunner(),
                new EnumsRunner(),
                new ExceptionsRunner(),
                new DirectoriesRunner(),
                new CalculatorRunner(),
                new ReflectionRunner(),
                new StyleCopRunner(),
                new ExcelRunner(),
                new SerializationRunner(),
                new ThreadsRunner()
            };

            foreach(var runner in runners)
            {
                runner.Run();
            }

            Console.ReadKey();
        }
    }
}
