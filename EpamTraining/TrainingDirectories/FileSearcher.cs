using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceClasses;
using System.IO;
using System.Configuration;

namespace TrainingDirectories
{
    public class FileSearcher
    {
        public IPrinter Printer;
        private List<FileInfo> MatchingFiles;
        private string _directoryPath;

        public FileSearcher(IPrinter printer)
        {
            try
            {
                Printer = printer;
                MatchingFiles = new List<FileInfo>();
                _directoryPath = ConfigurationSettings.AppSettings["directoryToSearchFiles"];
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void SearchMatchingFiles(string nameFragment)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(_directoryPath);
                FileInfo[] files = directory.GetFiles();

                foreach (var file in files)
                {
                    if (file.Name.Contains(nameFragment) && file.Extension == ".txt")
                    {
                        MatchingFiles.Add(file);
                    }
                }

                if (MatchingFiles.Count == 0)
                {
                    Printer.Print("No files found");
                }
                else
                {
                    Printer.Print("Matching text files: ");
                    foreach (var file in MatchingFiles)
                    {
                        Printer.Print(file.Name);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
