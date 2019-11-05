using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
    public static class EnumExtension
    {
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
                Console.WriteLine(i+": "+(int)i);
            }
        }
    }
}
