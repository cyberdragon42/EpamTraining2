using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using ServiceClasses;

namespace Excel
{
    public class DirectoryReader
    {
        IPrinter Printer;
        ExcelWriter excelWriter;
        private string OutputFilePath;
        private string FirstDirectoryPath;
        private string SecondDirectoryPath;
        private HashSet<string> FirstUniqueFileList;
        private HashSet<string> SecondUniqueFileList;
        private List<string> FirstFileList;
        private List<string> SecondFileList;
        private IEnumerable<string> DouplicateFiles;

        public DirectoryReader()
        {
            Printer = new ConsolePrinter();
            excelWriter = new ExcelWriter();
            FirstUniqueFileList = new HashSet<string>();
            SecondUniqueFileList = new HashSet<string>();
            FirstFileList = new List<string>();
            SecondFileList = new List<string>();
            try
            {
                OutputFilePath = ConfigurationSettings.AppSettings["excelOutputFilePath"];
                FirstDirectoryPath = ConfigurationSettings.AppSettings["firstDirectoryAddress"];
                SecondDirectoryPath = ConfigurationSettings.AppSettings["secondDirectoryAddress"];
            }

            catch(Exception e)
            {

            }

        }

        public void ReadCollections()
        {
            DirectoryInfo firstDirectory = new DirectoryInfo(FirstDirectoryPath);
            FileInfo[] firstFiles = firstDirectory.GetFiles();
            foreach(var file in firstFiles)
            {
                FirstFileList.Add(file.Name);
            }
            
            DirectoryInfo secondDirectory = new DirectoryInfo(SecondDirectoryPath);
            FileInfo[] secondFiles = secondDirectory.GetFiles();
            foreach (var file in secondFiles)
            {
                SecondFileList.Add(file.Name);
            }

        }

        public void GetUniqueValues()
        {
            foreach (var file in FirstFileList)
            {
                FirstUniqueFileList.Add(file);
            }

            foreach (var file in SecondFileList)
            {
                SecondUniqueFileList.Add(file);
            }
        }

        public void GetDouplicates()
        {
            DouplicateFiles = FirstFileList.Intersect(SecondFileList);
        }

        public void DisplayCollections()
        {
            string wayOfDisplay = ConfigurationSettings.AppSettings["wayOfDisplay"];
            switch (wayOfDisplay)
            {
                case "console":
                    DisplayOnConsole();
                    break;
                case "file":
                    DisplayIntoFile();
                    break;
                default:
                    Printer.Print("Collection can not be displayed");
                    break;
            }
        }

        public void DisplayOnConsole()
        {
            Printer.Print("unique files from first directory:");
            foreach (var file in FirstUniqueFileList)
            {
                Printer.Print(file);
            }

            Printer.Print("unique files from second directory:");
            foreach (var file in SecondUniqueFileList)
            {
                Printer.Print(file);
            }

            Printer.Print("duplicate files:");
            foreach (var file in DouplicateFiles)
            {
                Printer.Print(file);
            }
        }

        public void DisplayIntoFile()
        {

        }
    }
}
