using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MicrosoftExcel = Microsoft.Office.Interop.Excel;
using ServiceClasses;

namespace Excel
{
    public class ExcelReader
    {
        public IPrinter Printer;
        public ExcelWriter excelWriter;
        public ILogger Logger;
        private string InputFilePath;
        private string OutputFilePath;
        private int FirstColumnNumber;
        private int SecondColumnNumber;
        private HashSet<string> FirstCollection;
        private HashSet<string> SecondCollection;

        public ExcelReader()
        {
             Printer = new ConsolePrinter();
             Logger = new  MyLogger();
             excelWriter = new ExcelWriter();
             FirstCollection = new HashSet<string>();
             SecondCollection = new HashSet<string>();
            try
            { 
                InputFilePath = ConfigurationSettings.AppSettings["excelInputFilePath"];
                OutputFilePath = ConfigurationSettings.AppSettings["excelOutputFilePath"];
                FirstColumnNumber = Convert.ToInt32(ConfigurationSettings.AppSettings["firstColumnNumber"]);
                SecondColumnNumber = Convert.ToInt32(ConfigurationSettings.AppSettings["secondColumnNumber"]);
            }
            catch(Exception e)
            {
                Printer.Print(e.Message);
                Logger.Log(e.Message);
            }
        }

        public void ReadCollections()
        {
            MicrosoftExcel.Application excelApplication;
            MicrosoftExcel.Workbook excelWorkBook;
            MicrosoftExcel.Worksheet excelWorkSheet;
            MicrosoftExcel.Range range;

            string cell;
            int rowCount = 0;
            int columnCount = 0;

            try
            {
                excelApplication = new MicrosoftExcel.Application();
                excelWorkBook = excelApplication.Workbooks.Open(InputFilePath, 0, true, 5, "", "", true,
                    MicrosoftExcel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                excelWorkSheet = (MicrosoftExcel.Worksheet)excelWorkBook.Worksheets.get_Item(1);

                range = excelWorkSheet.UsedRange;
                rowCount = range.Rows.Count;
                columnCount = range.Columns.Count;

                for (int i = 1; i <= rowCount; ++i)
                {
                    cell = (string)(range.Cells[i, FirstColumnNumber] as MicrosoftExcel.Range).Value2;
                    FirstCollection.Add(cell);
                }

                for (int i = 1; i <= rowCount; ++i)
                {
                    cell = (string)(range.Cells[i, SecondColumnNumber] as MicrosoftExcel.Range).Value2;
                    SecondCollection.Add(cell);
                }

                excelWorkBook.Close();
                excelApplication.Quit();
            }
            catch (Exception e)
            {
                Printer.Print(e.Message);
                Logger.Log(e.Message);
            }

        }

        public void DisplayCollections()
        {
            string wayOfDisplay = ConfigurationSettings.AppSettings["wayOfDisplay"];
            switch(wayOfDisplay)
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

        private void DisplayOnConsole()
        {
            Printer.Print("first collection:");
            foreach (var cell in FirstCollection)
            {
                Printer.Print(cell);
            }

            Printer.Print("second collection:");
            foreach (var cell in SecondCollection)
            {
                Printer.Print(cell);
            }
        }

        public void DisplayIntoFile()
        {
            try
            {
                excelWriter.WriteIntoExcelFile(FirstCollection, 1, OutputFilePath);
                excelWriter.WriteIntoExcelFile(SecondCollection, 3, OutputFilePath);
            }
            catch(Exception e)
            {
                Logger.Log(e.Message);
            }
        }
    }
}
