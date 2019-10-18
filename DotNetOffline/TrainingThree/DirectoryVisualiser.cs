using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrainingThree
{
    public class DirectoryVisualiser
    {
        public string DirectoryPath { get; set; }
        IPrinter Printer;
        ILogger Logger;

        #region Constructors
        public DirectoryVisualiser()
        {
            Printer = new ConsolePrinter();
            Logger = new TextFileLogger();
        }
        public DirectoryVisualiser(string directoryPath)
        {
            Printer = new ConsolePrinter();
            Logger = new TextFileLogger();
            DirectoryPath = directoryPath;
        }
        #endregion
        public void GetListOfFiles()
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(DirectoryPath);
                DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
                Printer.Print("files:");
                FileInfo[] files = directoryInfo.GetFiles();
                foreach (var file in files)
                {
                    Printer.Print(file.Name);
                }

                foreach (var directory in subDirectories)
                {
                    Printer.Print("subdirectory:" + directory.Name);
                    Printer.Print("subdirectory files:");
                    FileInfo[] subFiles = directory.GetFiles();
                    foreach (var file in subFiles)
                    {
                        Printer.Print(file.Name);
                    }
                }
            }

            catch(Exception e)
            {
                Printer.Print(e.Message);
                Logger.Log(e.Message);
            }
        }

    }
}
