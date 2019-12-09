using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceClasses;

namespace TrainingEnums
{
    public class ColorsDisplayer
    {
        IPrinter Printer;
        public ColorsDisplayer(IPrinter printer)
        {
            Printer = printer;
        }

        public void DisplayMonth(int n)
        {
            if (n > 0 && n <= 12)
            {
                Printer.Print(Enum.GetName(typeof(Months), n - 1));
            }
            else
            {
                Printer.Print("Incorrect month number");
            }
        }

    }
}
