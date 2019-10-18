using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingOne;
using TrainingThree;
using TrainingTwo;
using TrainingFour;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskRunner taskRunner = new TaskRunner();
            MyLogger myLogger = new MyLogger();

            try
            {
                taskRunner.TaskPerson();
            }
            catch (ArgumentException e) when (e.ParamName == "age")
            {
                Console.WriteLine("Argument exception, age should be greater than 0");
                myLogger.Write(e.Message);
            }
            try
            {
                taskRunner.TaskRectangle();
            }
            catch (ArgumentException e) when (e.ParamName == "width")
            {
                Console.WriteLine("Argument exception, width should be greater than 0");
                myLogger.Write(e.Message);
            }
            catch (ArgumentException e) when (e.ParamName == "height")
            {
                Console.WriteLine("Argument exception, height should be greater than 0");
                myLogger.Write(e.Message);
            }

            try
            {
                taskRunner.TaskMonthEnum();
                taskRunner.TaskLongRangeEnum();
            }

            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Index out of range exception");
                myLogger.Write(e.Message);
            }
            catch (StackOverflowException e)
            {
                Console.WriteLine("Stack overflow exception");
                myLogger.Write(e.Message);
            }
            catch (ArgumentException e) when (e.ParamName == "a")
            {
                Console.WriteLine("Argument exception, a is less than 0");
                myLogger.Write(e.Message);
            }

            catch (ArgumentException e) when (e.ParamName == "b")
            {
                Console.WriteLine("Argument exception, b is greater than 0");
                myLogger.Write(e.Message);
            }

            myLogger.Read();
            Console.ReadKey();
        }
    }
}
