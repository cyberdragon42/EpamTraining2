using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceClasses;

namespace Exceptions
{
    public class ExceptionsGenerator
    {
        IPrinter Printer;
        public ExceptionsGenerator(IPrinter printer)
        {
            Printer = printer;
        }

        public void DoSomeMath(int a, int b)
        {
            if (a < 0)
               throw new ArgumentException("Parameter should be greater than 0", "a");
            if (b > 0)
               throw new ArgumentException("Parameter should be less than 0", "b");
            else
                Printer.Print("Arguments are correct");
        }

        public int GenerateInfiniteRecursion(int i)
        {
            return i * GenerateInfiniteRecursion(i + 1);
        }

        public int GenereteIndexOutOfRange(int i)
        {
            int[] sampleArray = new int[] { 8, 3, 5, 4, 9 };
            return sampleArray[i];
        }
    }
}
