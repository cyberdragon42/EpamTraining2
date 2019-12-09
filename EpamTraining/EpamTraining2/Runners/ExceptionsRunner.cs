using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingExceptions;
using ServiceClasses;

namespace EpamTraining2
{
    public class ExceptionsRunner:IRunner
    {
        ILogger Logger;
        public ExceptionsRunner()
        {
            Logger = new TextFileLogger();
        }

        public void Run()
        {
            try
            {
                RunTaskStackOverflowAndIndexOutofRangeExceptions();
            }

            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Index out of range exception");
                Logger.Log("Index out of range exception");
            }
            catch (StackOverflowException e)
            {
                Console.WriteLine("Stack overflow exception");
                Logger.Log("Stack overflow exception");
            }
            try
            {
                RunTaskArgumentExceptions();
            }
            catch (ArgumentException e) when (e.ParamName == "a")
            {
                Console.WriteLine("Argument exception, a is less than 0");
                Logger.Log("Argument exception, a is less than 0");
            }

            catch (ArgumentException e) when (e.ParamName == "b")
            {
                Console.WriteLine("Argument exception, b is greater than 0");
                Logger.Log("Argument exception, b is greater than 0");
            }
        }

        public void RunTaskStackOverflowAndIndexOutofRangeExceptions()
        {
            Console.WriteLine("____________Task Exceptions____________");
            ExceptionsGenerator exceptionsViewer = new ExceptionsGenerator(new ConsolePrinter());
            exceptionsViewer.GenereteIndexOutOfRangeException();
            exceptionsViewer.GenerateInfiniteRecursion(8);
        }

        public void RunTaskArgumentExceptions()
        {
            Console.WriteLine("____________Task Argument Exception____________");
            ExceptionsGenerator exceptionsViewer = new ExceptionsGenerator(new ConsolePrinter());
            Console.WriteLine("Please, enter a: ");
            string aFromConsole = Console.ReadLine();
            Console.WriteLine("Please, enter b: ");
            string bFromConsole = Console.ReadLine();
            int convertedA = 0;
            int convertedB = 0;
            if (Int32.TryParse(aFromConsole, out convertedA) && Int32.TryParse(bFromConsole, out convertedB))
            {
                exceptionsViewer.DoSomeMath(convertedA, convertedB);
            }
            else
            {
                Console.WriteLine("Incorrect input: a or b is not a number");
            }
        }
    }
}
