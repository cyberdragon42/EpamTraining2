using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceClasses;

namespace TrainingDirectories
{
    public class DirectoryVisualizer
    {
        IPrinter Printer;
        private string _directoryPath;

        #region Constructors
        public DirectoryVisualizer(IPrinter printer)
        {
            try
            {
                Printer = printer;
                _directoryPath = ConfigurationSettings.AppSettings["visualizedDirectory"];
            }

            catch(Exception e)
            {
                throw e;
            }
        }
        #endregion

        public void PrintFiles(DirectoryInfo targetDirectory)
        {
            try
            {
                Printer.Print("directory: " + targetDirectory.Name);
                Printer.Print("files:");
                FileInfo[] files = targetDirectory.GetFiles();
                if (files.Length > 0)
                {
                    foreach (var file in files)
                    {
                        Printer.Print(file.Name);
                    }
                }
                else
                {
                    Printer.Print("there are no files in directory");
                }
            }

            catch(Exception e)
            {
                throw e;
            }
        }

        public void VisualizeDirectory()
        {
            try
            {
                DirectoryInfo mainDirectory = new DirectoryInfo(_directoryPath);
                DirectoryInfo[] subDirectories = mainDirectory.GetDirectories();
                PrintFiles(mainDirectory);

                if (subDirectories.Length > 0)
                {
                    foreach (var subdirectory in subDirectories)
                    {
                        PrintFiles(subdirectory);
                    }
                }
                else
                {
                    Printer.Print("There are no subdirectories in this directory");
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
