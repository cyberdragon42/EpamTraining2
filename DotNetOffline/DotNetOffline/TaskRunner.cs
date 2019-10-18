using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingOne;
using TrainingTwo;
using TrainingThree;

namespace Runner
{
    public class TaskRunner
    {
        public void TaskPerson()
        {
            Console.WriteLine("Task1: Person");

            Console.WriteLine("Please, enter name of person: ");
            string nameFromConsole = Console.ReadLine();

            Console.WriteLine("Please, enter surname of person: ");
            string surnameFromConsole = Console.ReadLine();

            Console.WriteLine("Please, enter age of person: ");
            string ageFromConsole = Console.ReadLine();
            int convertedAge = 0;
            if(Int32.TryParse(ageFromConsole,out convertedAge))
            {
                Person person = new Person(nameFromConsole, surnameFromConsole, convertedAge);
                Console.WriteLine("Please, enter age to compare: ");
                string numberFromConsole = Console.ReadLine();
                int convertedNumber = 0;
                if(Int32.TryParse(numberFromConsole, out convertedNumber))
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

        public void TaskRectangle()
        {
            Console.WriteLine("Task2: rectangle");

            Console.WriteLine("Please, enter rectangle width: ");
            string widthFromConsole = Console.ReadLine();

            Console.WriteLine("Please, enter rectangle heignt: ");
            string heighFromConsole = Console.ReadLine();
            int convertedWidth = 0;
            int convertedHeigh = 0;
            if (Int32.TryParse(widthFromConsole, out convertedWidth)&& Int32.TryParse(heighFromConsole, out convertedHeigh))
            {
                Rectangle rectangle = new Rectangle(1,1,convertedWidth,convertedHeigh);
                Console.Write("Perimeter= ");
                rectangle.Perimeter();
            }
            else
            {
                Console.WriteLine("Incorrect input: width or heigh is not a number");
            }
        }

        public void TaskMonthEnum()
        {
            Console.WriteLine("Task3: Month enum");
            EnumDisplayer enumDisplayer = new EnumDisplayer();
            Console.WriteLine("Please, enter month number:");
            string monthFromConsole = Console.ReadLine();
            int convertedMonth = 0;
            if(Int32.TryParse(monthFromConsole, out convertedMonth))
            {
                enumDisplayer.DisplayMonth(convertedMonth);
            }
            else
            {
                Console.WriteLine("Incorrect input: month is not a number");
            }
        }

        public void TaskColorsEnum()
        {
            //EnumDisplayer enumDisplayer = new EnumDisplayer();
            //enumDisplayer.DisplaySortedColors();
        }

        public void TaskLongRangeEnum()
        {
            Console.WriteLine("Task5: Long range enum");
            EnumDisplayer enumDisplayer = new EnumDisplayer();
            enumDisplayer.DisplayLongRange();
        }

        public void TaskStackOverflowAndIndexOutOfRangeExceptions()
        {
            Console.WriteLine("Task6: exceptions");
            ExceptionsGenerator exceptionsViewer = new ExceptionsGenerator();
            exceptionsViewer.GenereteIndexOutOfRange(100);
            exceptionsViewer.GenerateInfiniteRecursion(8);
        }

        public void TaskArgumentExceptions()
        {
            Console.WriteLine("Task7: argument exception");
            ExceptionsGenerator exceptionsViewer = new ExceptionsGenerator();
            string aFromConsole = Console.ReadLine();
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

        public void TaskVisualiseDirectory()
        {
            DirectoryVisualiser directoryVisualiser = new DirectoryVisualiser();
            string directoryFromConsole = Console.ReadLine();
            directoryVisualiser.DirectoryPath = directoryFromConsole;
            directoryVisualiser.GetListOfFiles();
        }

    }
}
