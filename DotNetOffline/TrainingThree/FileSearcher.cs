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
        public string DirectoryPath { get; set; }
        private List<FileInfo> MatchingFiles;
        public IPrinter Printer;
        public ILogger Logger;

        public FileSearcher()
        {
            Printer = new ConsolePrinter();
            Logger = new MyLogger();
            MatchingFiles = new List<FileInfo>();
        }

        public void SearchMatchingFiles(string nameFragment)
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
    }
}
