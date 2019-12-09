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
                Matrix matrix = new Matrix(new ConsolePrinter(),100,100,4);
                matrix.CountSumWithThreads();
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Logger.Log(e.Message);
            }
        }
    }
}
