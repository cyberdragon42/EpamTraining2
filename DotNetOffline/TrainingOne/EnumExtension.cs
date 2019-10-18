using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingOne
{
    public static class EnumExtension
    {
        public static List<string> DisplaySortedColors(this Colors colors)
        {
            List<Colors> arrayOfColors = new List<Colors>();
            foreach (Colors i in Enum.GetValues(typeof(Colors)))
            {
                arrayOfColors.Add(i);
            }
            arrayOfColors.Sort();

            List<string> arrayOfSortedColors = new List<string>();

            foreach (var i in arrayOfColors)
            {
                arrayOfSortedColors.Add(String.Format($"{0}: {1}", i, (int)i));
            }
            return arrayOfSortedColors;
        }
    }
}
