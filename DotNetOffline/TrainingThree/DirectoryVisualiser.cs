using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ServiceClasses;

namespace Directories
{
    public class DirectoryVisualiser
    {
        public string DirectoryPath { get; set; }
        IPrinter Printer;
        ILogger Logger;

        #region Constructors
        public DirectoryVisualiser(IPrinter printer, ILogger logger)
        {
            Printer = printer;
            Logger = logger;
        }
        public DirectoryVisualiser(string directoryPath)
        {
            Printer = new ConsolePrinter();
            Logger = new MyLogger();
            DirectoryPath = directoryPath;
        }
        #endregion
        public void GetListOfFiles()
        {
            try
            {
                DirectoryInfo mainDirectory = new DirectoryInfo(DirectoryPath);
                DirectoryInfo[] subDirectories = mainDirectory.GetDirectories();
                Printer.Print("files:");
                FileInfo[] files = mainDirectory.GetFiles();
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
