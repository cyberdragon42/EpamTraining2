using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceClasses;
using TrainingThreads;

namespace EpamTraining2
{
    public class ThreadsRunner: IRunner
    {
        ILogger Logger;
        public ThreadsRunner()
        {
            Logger = new TextFileLogger();
        }

        public void Run()
        {
            try
            {
                Console.WriteLine("____________Task Threading____________");
                Console.WriteLine("4 threads are created for matrix 100x100");
                Matrix matrix = new Matrix(100,4);
                matrix.CountSumWithThreads();
                Console.WriteLine("Sum= " + matrix.Sum);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Logger.Log(e.Message);
            }
        }
    }
}
