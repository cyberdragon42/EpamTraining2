using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingOne
{
    public class EnumDisplayer
    {
        IPrinter Printer;
        public EnumDisplayer()
        {
            Printer = new ConsolePrinter();
        }

        public void DisplayMonth(int n)
        {
            if (n > 0 && n <= 12)
            {
                Printer.Print(Enum.GetName(typeof(Month), n - 1));
            }
            else
            {
                Printer.Print("Incorrect month number");
            }
        }

        public void DisplayColors()
        { 
            List<Colors> arrayOfColors = new List<Colors>();
            foreach (Colors i in Enum.GetValues(typeof(Colors)))
            {
                arrayOfColors.Add(i);
            }
            arrayOfColors.Sort();

            foreach (var i in arrayOfColors)
            {
                Printer.Print($"{i}: {((int)i).ToString()}");
            }
        }

        public void DisplayLongRange()
        {
            Printer.Print("Max long range:");
            Printer.Print(((long)LongRange.Max).ToString());
            Printer.Print("Min long range:");
            Printer.Print(((long)LongRange.Min).ToString());
        }
    }

    enum LongRange : long
    {
        Min = -9223372036854775808,
        Max = 9223372036854775807
    }

    enum Month
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }

    public enum Colors
    {
        Red = 45,
        Cyan = 1,
        Magenta = 66,
        Blue = 8,
        Green = 36,
        Black = 17,
        White = 101
    }
}
