using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrainingThree
{
    public class TextFileLogger : ILogger
    {
        private string LogFilePath = @"D:\logFolder\log.txt";
        public void Log(string message)
        {
            //write in logfile
            using (StreamWriter sw = new StreamWriter(LogFilePath, false, System.Text.Encoding.Default))
            {
                sw.Write(message);
            }
        }
    }
}
