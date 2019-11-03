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
        IPrinter Printer;

        #region Constructors
        public DirectoryVisualiser(IPrinter printer)
        {
            Printer = printer;
        }
        public DirectoryVisualiser(string directoryPath)
        {
            Printer = new ConsolePrinter();
            DirectoryPath = directoryPath;
        }
        #endregion

        public string DirectoryPath { get; set; }
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
                throw new Exception(e.Message);
            }
        }
    }
}
