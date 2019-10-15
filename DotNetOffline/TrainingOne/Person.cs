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
            _age = age;
            Printer = new ConsolePrinter();
        }

        public void CompareAges(int n)
        {
            //return Age > n ? String.Format("{0} {1} older than {2}", Name, Surname, n) : String.Format("{0} {1} not older than {2}", Name, Surname, n);
            if (Age > n)
                Printer.Print(String.Format("{0} {1} older than {2}", Name, Surname, n));
            else if (Age < n)
                Printer.Print(String.Format("{0} {1} younger than {2}", Name, Surname, n));
            else
                Printer.Print(String.Format("{0} {1} is {2}", Name, Surname, n));
        }
    }
}
