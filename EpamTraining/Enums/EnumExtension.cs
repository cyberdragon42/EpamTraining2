using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingEnums
{
    public static class EnumExtension
    {
        public static void SortColors(this Colors color)
        {
            foreach (var c in Enum.GetValues(typeof(Colors)))
            {
                Console.WriteLine(c + ": " + (int)c);
            }
        }
    }
}
