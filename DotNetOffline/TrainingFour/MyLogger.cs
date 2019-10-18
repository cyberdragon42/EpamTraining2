using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrainingFour
{
    public class MyLogger : ILogger
    {
        private string LogFilePath = @"D:\logFolder\mylog.txt";
        IPrinter Printer;

        public MyLogger()
        {
            Printer = new ConsolePrinter();
        }

        public void Read()
        {
            using (StreamReader streamReader = new StreamReader(LogFilePath))
            {
                Printer.Print(streamReader.ReadToEnd());
            }

        }
        public void Write(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(LogFilePath, true, System.Text.Encoding.Default))
            {
                streamWriter.Write(DateTime.Now + " " + message);
            }

        }
    }
}
