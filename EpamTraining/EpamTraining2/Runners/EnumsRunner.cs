using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingEnums;
using ServiceClasses;

namespace EpamTraining2
{
    public class EnumsRunner : IRunner
    {
        ILogger Logger;
        public EnumsRunner()
        {
            Logger = new TextFileLogger();
        }

        public void Run()
        {
            try
            {
                try
                {
                    RunTaskPerson();
                }
                catch (ArgumentException e) when (e.ParamName == "age")
                {
                    Console.WriteLine("Argument exception, age should be greater than 0");
                    Logger.Log("Argument exception, age should be greater than 0");
                }
                try
                {
                    RunTaskRectangle();
                }
                catch (ArgumentException e) when (e.ParamName == "width")
                {
                    Console.WriteLine("Argument exception, width should be greater than 0");
                    Logger.Log("Argument exception, width should be greater than 0");
                }
                catch (ArgumentException e) when (e.ParamName == "height")
                {
                    Console.WriteLine("Argument exception, height should be greater than 0");
                    Logger.Log("Argument exception, height should be greater than 0");
                }

                RunTaskMonthEnum();
                RunTaskLongRangeEnum();
                RunTaskColorsEnum();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Logger.Log(e.Message);
            }
        }

        public void RunTaskPerson()
        {
            Console.WriteLine("____________Task Person____________");

            Console.WriteLine("Please, enter name of person: ");
            string nameFromConsole = Console.ReadLine();

            Console.WriteLine("Please, enter surname of person: ");
            string surnameFromConsole = Console.ReadLine();

            Console.WriteLine("Please, enter age of person: ");
            string ageFromConsole = Console.ReadLine();
            int convertedAge = 0;
            if (Int32.TryParse(ageFromConsole, out convertedAge))
            {
                Person person = new Person(nameFromConsole, surnameFromConsole, convertedAge, new ConsolePrinter());
                Console.WriteLine("Please, enter age to compare: ");
                string numberFromConsole = Console.ReadLine();
                int convertedNumber = 0;
                if (Int32.TryParse(numberFromConsole, out convertedNumber))
                {
                    person.CompareAges(convertedNumber);
                }
                else
                {
                    Console.WriteLine("Incorrect input: age is not a number");
                }
            }
            else
            {
                Console.WriteLine("Incorrect input: age is not a number");
            }
        }

        public void RunTaskRectangle()
        {
            Console.WriteLine("____________Task Rectangle____________");

            Console.WriteLine("Please, enter rectangle width: ");
            string widthFromConsole = Console.ReadLine();

            Console.WriteLine("Please, enter rectangle heignt: ");
            string heighFromConsole = Console.ReadLine();
            int convertedWidth = 0;
            int convertedHeigh = 0;
            if (Int32.TryParse(widthFromConsole, out convertedWidth) && Int32.TryParse(heighFromConsole, out convertedHeigh))
            {
                Rectangle rectangle = new Rectangle(1, 1, convertedWidth, convertedHeigh);
                Console.WriteLine("Perimeter= "+rectangle.Perimeter());
            }
            else
            {
                Console.WriteLine("Incorrect input: width or heigh is not a number");
            }
        }

        public void RunTaskMonthEnum()
        {
            Console.WriteLine("____________Task Month Enum____________");
            ColorsDisplayer colorsDisplayer = new ColorsDisplayer(new ConsolePrinter());
            Console.WriteLine("Please, enter month number:");
            string monthFromConsole = Console.ReadLine();
            int convertedMonth = 0;
            if (Int32.TryParse(monthFromConsole, out convertedMonth))
            {
                colorsDisplayer.DisplayMonth(convertedMonth);
            }
            else
            {
                Console.WriteLine("Incorrect input: month is not a number");
            }

        }

        public void RunTaskColorsEnum()
        {
            Console.WriteLine("____________Task Sort Colors____________");
            Colors color = Colors.Black;
            color.SortColors();
        }

        public void RunTaskLongRangeEnum()
        {
            Console.WriteLine("____________Task Long Range____________");
            Console.WriteLine("Max long range:");
            Console.WriteLine(((long)LongRange.Max));
            Console.WriteLine("Min long range:");
            Console.WriteLine(((long)LongRange.Min));
        }
    }
}
