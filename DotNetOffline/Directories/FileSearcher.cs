using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ServiceClasses;


namespace Directories
{
    public class FileSearcher
    {
        public IPrinter Printer;
        private List<FileInfo> MatchingFiles;

        public FileSearcher(IPrinter printer)
        {
            Printer = printer;
            MatchingFiles = new List<FileInfo>();
        }

        public string DirectoryPath { get; set; }
        public void SearchMatchingFiles(string nameFragment)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(DirectoryPath);
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
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
