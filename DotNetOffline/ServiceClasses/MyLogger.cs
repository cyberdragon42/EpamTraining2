using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace ServiceClasses
{
    public class MyLogger : ILogger
    {
        private string LogFilePath;
        private IPrinter Printer;

        public MyLogger()
        {
            Printer = new ConsolePrinter();
            LogFilePath = ConfigurationSettings.AppSettings["LogFilePath"].ToString();
        }

        public void Read()
        {
            using (StreamReader streamReader = new StreamReader(LogFilePath))
            {
                Printer.Print(streamReader.ReadToEnd());
            }

        }
        public void Log(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(LogFilePath, true, System.Text.Encoding.Default))
            {
                streamWriter.WriteLine(DateTime.Now + " " + message);
            }

        }
    }
}
