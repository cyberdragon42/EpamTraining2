using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingOne
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(string s)
        {
            Console.WriteLine(s);
        }
    }
}
