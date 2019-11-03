using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Directories;
using Enums;
using Exceptions;
using Excel;
using ServiceClasses;

namespace Runner
{
    public class TaskRunner
    {
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

        public void RunTaskRectangle()
        {
            Console.WriteLine("____________Task Rectangle____________");

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

        public void RunTaskMonthEnum()
        {
            Console.WriteLine("____________Task Month Enum____________");
            EnumDisplayer enumDisplayer = new EnumDisplayer(new ConsolePrinter());
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

        public void RunTaskColorsEnum()
        {
            Console.WriteLine("____________Task Sort Colors____________");
            EnumDisplayer enumDisplayer = new EnumDisplayer(new ConsolePrinter());
            enumDisplayer.DisplayColors();
        }

        public void RunTaskLongRangeEnum()
        {
            Console.WriteLine("____________Task Long Range Enum____________");
            EnumDisplayer enumDisplayer = new EnumDisplayer(new ConsolePrinter());
            enumDisplayer.DisplayLongRange();
        }

        public void RunTaskStackOverflowAndIndexOutOfRangeExceptions()
        {
            Console.WriteLine("____________Task Exceptions____________");
            ExceptionsGenerator exceptionsViewer = new ExceptionsGenerator(new ConsolePrinter());
            exceptionsViewer.GenereteIndexOutOfRange(100);
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

        public void RunTaskVisualiseDirectory()
        {
            Console.WriteLine("____________Task Directory Visualiser____________");
            DirectoryVisualiser directoryVisualiser = new DirectoryVisualiser(new ConsolePrinter());
            Console.WriteLine("Please, enter directory: ");
            string directoryFromConsole = Console.ReadLine();
            directoryVisualiser.DirectoryPath = directoryFromConsole;
            directoryVisualiser.GetListOfFiles();
        }

        public void RunTaskSearchMatchingFiles()
        {
            Console.WriteLine("____________Task Matching Files Searcher____________");
            FileSearcher fileSearcher = new FileSearcher(new ConsolePrinter());
            Console.WriteLine("Please, enter fragment of file name: ");
            string nameFromConsole = Console.ReadLine();
            fileSearcher.SearchMatchingFiles(nameFromConsole);
        }

        public void RunTaskListsFromExcel()
        {
            Console.WriteLine("____________Task Excel Collections Displayer____________");
            ExcelCollectionDisplayer excelCollectionDisplayer = new ExcelCollectionDisplayer();
            excelCollectionDisplayer.ReadCollections();
            excelCollectionDisplayer.WriteCollections();
        }

        public void RunTaskExcelDirectory()
        {
            Console.WriteLine("____________Task Directory Excel Displayer____________");
            DirectoryCollectionDisplayer directoryCollectionDisplayer = new DirectoryCollectionDisplayer();
            directoryCollectionDisplayer.ReadCollections();
            directoryCollectionDisplayer.GetUniqueValues();
            directoryCollectionDisplayer.GetDouplicates();
            directoryCollectionDisplayer.WriteCollections();
        }

    }
}
