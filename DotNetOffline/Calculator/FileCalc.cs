using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using ServiceClasses;

namespace Calculator
{
    public class FileCalc : ICalc
    {
        private double X;
        private double Y;
        private double Result;
        private char Op;

        private ILogger Logger;
        public FileCalc()
        {
            Logger = new MyLogger();
        }

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
            string stringParameters;
            string calcReadFilePath = ConfigurationSettings.AppSettings["calcReadFilePath"];
            using (StreamReader sr = new StreamReader(calcReadFilePath, true))
            {
                stringParameters = sr.ReadLine();
            }

            string[] splittedParameters = stringParameters.Split(' ');
            bool isXCorrect = Double.TryParse(splittedParameters[0], out X);
            bool isYCorrect = Double.TryParse(splittedParameters[1], out Y);
            bool isOpCorrect = Char.TryParse(splittedParameters[2], out Op);
            if (isOpCorrect && isXCorrect && isYCorrect)
                return true;
            return false;
        }

        public void WriteResult()
        {
            try
            {
                string calcWriteFilePath = ConfigurationSettings.AppSettings["calcWriteFilePath"];
                using (StreamWriter sw = new StreamWriter(calcWriteFilePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine("Result of calculation: "+Result);
                }
            }

            catch (Exception e)
            {
                Logger.Log(e.Message);
            }
        }
    }
}
