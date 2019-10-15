using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingOne
{
    public static class EnumExtension
    {
        static IPrinter Printer;
        static EnumExtension()
        {
            Printer = new ConsolePrinter();
        }
        public static void DisplaySortedColors(this Colors colors)
        {
            List<Colors> arrayOfColors = new List<Colors>();
            foreach (Colors i in Enum.GetValues(typeof(Colors)))
            {
                arrayOfColors.Add(i);
            }
            arrayOfColors.Sort();

            foreach (var i in arrayOfColors)
            {
                Printer.Print(String.Format($"{0}: {1}",i,(int)i));
            }
        }
    }
}
