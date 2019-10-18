using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingOne
{
    public struct Person
    {
        private int _age;
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age
        {
            get
            {
                return _age;
            }

            set
            {
                if (value > 0)
                    _age = value;
            }
        }
        public IPrinter Printer;

        public Person(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Printer = new ConsolePrinter();
            if (age <= 0)
                throw new ArgumentException("Age should be greater than 0","age");
            _age = age;
        }

        public void CompareAges(int n)
        {
            if (Age > n)
                Printer.Print(String.Format("{0} {1} older than {2}", Name, Surname, n));
            else if (Age < n)
                Printer.Print(String.Format("{0} {1} younger than {2}", Name, Surname, n));
            else
                Printer.Print(String.Format("{0} {1} is {2}", Name, Surname, n));
        }
    }
}
