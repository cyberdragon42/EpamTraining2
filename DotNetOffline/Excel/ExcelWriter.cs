using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrosoftExcel = Microsoft.Office.Interop.Excel;

namespace Excel
{
    public class ExcelWriter
    {
        public void WriteIntoExcelFile(IEnumerable<string> collection, int columnNumber, string outputFilePath)
        {
            MicrosoftExcel.Application excelApp = new MicrosoftExcel.Application();
            MicrosoftExcel.Workbook  excelWorkbook = excelApp.Workbooks.Open(outputFilePath);
            MicrosoftExcel.Worksheet excelWorksheet = excelWorkbook.ActiveSheet;
            try
            {
                int i = 1;
                foreach (var cell in collection)
                {
                    excelWorksheet.Cells[i, columnNumber] = cell;
                    ++i;
                }
                excelWorkbook.Save();
                excelWorkbook.Close();
                excelApp.Quit();
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
