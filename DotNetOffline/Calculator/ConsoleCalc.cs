using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ConsoleCalc:ICalc
    {
        private double X;
        private double Y;
        private double Result;
        private char Op;

        public double Calculation(double x, double y, char op)
        {
            double result;
            switch (op)
            {
                case '+':
                    result = x + y;
                    break;
                case '-':
                    result = x - y;
                    break;
                case '/':
                    result = x / y;
                    break;
                case '*':
                    result = x * y;
                    break;
                default:
                    throw new ArgumentException("Invalid operation");
            }
            return result;
        }

        public void ExecuteCalculation()
        {
            bool isInputCorrect = ReadInput();
            if (!isInputCorrect)
                throw new ArgumentException("Wrong input");
            Result = Calculation(X, Y, Op);
            WriteResult();
        }

        public bool ReadInput()
        {
            Console.WriteLine("Please,enter x:");
            bool isXCorrect = Double.TryParse(Console.ReadLine(), out X);
            Console.WriteLine("Please,enter y:");
            bool isYCorrect = Double.TryParse(Console.ReadLine(), out Y);
            Console.WriteLine("Please,enter operation:");
            bool isOpCorrect = Char.TryParse(Console.ReadKey().ToString(), out Op);
            if (isXCorrect && isYCorrect)
                return true;
            return false;
        }

        public void WriteResult()
        {
            Console.WriteLine("Result of calculation: " + Result);
        }
    }
}
