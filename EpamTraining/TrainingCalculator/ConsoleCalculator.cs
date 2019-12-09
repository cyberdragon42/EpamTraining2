using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCalculator
{
    public class ConsoleCalculator: ICalculator
    {
        #region Fields
        private double X;
        private double Y;
        private double Result;
        private char Op;
        #endregion

        #region Methods
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
            Console.Write("Please,enter x: ");
            bool isXCorrect = Double.TryParse(Console.ReadLine(), out X);
            Console.Write("Please,enter y: ");
            bool isYCorrect = Double.TryParse(Console.ReadLine(), out Y);
            Console.Write("Please,enter operation: ");
            Op = Console.ReadLine().ToString()[0];
            if (isXCorrect && isYCorrect)
                return true;
            return false;
        }

        public void WriteResult()
        {
            Console.WriteLine("Result of calculation: " + Result);
        }
        #endregion
    }
}
