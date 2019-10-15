using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingTwo
{
    public class ExceptionsViewer
    {
        IPrinter Printer;
        public ExceptionsViewer()
        {
            Printer = new ConsolePrinter();
        }

        public void CombineExceptions()
        {
            try
            {
                GenereteIndexOutOfRange(100);
                GenerateInfiniteRecursion(3);
            }
            catch (IndexOutOfRangeException e)
            {
                Printer.Print("Index out of range exception");
            }

            catch (StackOverflowException)
            {
                Printer.Print("Stack overflow exception");
            }
        }

        public void DoSomeMath(int a, int b)
        {
            try
            {
                if (a < 0)
                    throw new ArgumentException("Parameter should be greater than 0", "a");
                if (b > 0)
                    throw new ArgumentException("Parameter should be less than 0", "b");
            }

            catch (ArgumentException e) when (e.ParamName == "a")
            {
                Printer.Print("Argument exception, a is less than 0");
            }

            catch (ArgumentException e) when (e.ParamName == "b")
            {
                Printer.Print("Argument exception, b is greater than 0");
            }
        }

        private int GenerateInfiniteRecursion(int i)
        {
            return i * GenerateInfiniteRecursion(i + 1);
        }

        private int GenereteIndexOutOfRange(int i)
        {
            int[] sampleArray = new int[] { 8, 3, 5, 4, 9 };
            return sampleArray[i];
        }
    }
}
