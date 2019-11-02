using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;
using ServiceClasses;
using Excel;
using System.Reflection;
using Reflection;

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
                try
                {
                    taskRunner.RunTaskPerson();
                }
                catch (ArgumentException e) when (e.ParamName == "age")
                {
                    Console.WriteLine("Argument exception, age should be greater than 0");
                    myLogger.Log(e.Message);
                }
                try
                {
                    taskRunner.RunTaskRectangle();
                }
                catch (ArgumentException e) when (e.ParamName == "width")
                {
                    Console.WriteLine("Argument exception, width should be greater than 0");
                    myLogger.Log(e.Message);
                }
                catch (ArgumentException e) when (e.ParamName == "height")
                {
                    Console.WriteLine("Argument exception, height should be greater than 0");
                    myLogger.Log(e.Message);
                }

                try
                {
                    taskRunner.RunTaskMonthEnum();
                    taskRunner.RunTaskColorsEnum();
                    taskRunner.RunTaskLongRangeEnum();
                    taskRunner.RunTaskStackOverflowAndIndexOutOfRangeExceptions();
                }

                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine("Index out of range exception");
                    myLogger.Log(e.Message);
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine("Stack overflow exception");
                    myLogger.Log(e.Message);
                }

                try
                {
                    taskRunner.RunTaskArgumentExceptions();
                }
                catch (ArgumentException e) when (e.ParamName == "a")
                {
                    Console.WriteLine("Argument exception, a is less than 0");
                    myLogger.Log(e.Message);
                }

                catch (ArgumentException e) when (e.ParamName == "b")
                {
                    Console.WriteLine("Argument exception, b is greater than 0");
                    myLogger.Log(e.Message);
                }

                taskRunner.RunTaskListsFromExcel();
                taskRunner.RunTaskExcelDirectory();
                taskRunner.RunTaskVisualiseDirectory();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                myLogger.Log(e.Message);
            }

            //myLogger.Read();
            Console.ReadKey();
        }
    }
}
