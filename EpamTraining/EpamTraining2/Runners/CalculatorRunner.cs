using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceClasses;
using TrainingCalculator;
using ServiceClasses;

namespace EpamTraining2
{
    public class CalculatorRunner: IRunner
    {
        ILogger Logger;
        public CalculatorRunner()
        {
            Logger = new TextFileLogger();
        }
        public void Run()
        {
            try
            {
                RunTaskFileCalculation();
                RunTaskConcoleCalculation();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Logger.Log(e.Message);
            }
        }
        
        public void RunTaskConcoleCalculation()
        {
            Console.WriteLine("____________Task Console Calculation____________");
            ICalculator calculator = new ConsoleCalculator();
            calculator.ExecuteCalculation();
        }

        public void RunTaskFileCalculation()
        {
            Console.WriteLine("____________Task File Calculation____________");
            ICalculator calculator = new FileCalculator();
            calculator.ExecuteCalculation();
            Console.WriteLine("The result is written into file");
        }
    }
}
