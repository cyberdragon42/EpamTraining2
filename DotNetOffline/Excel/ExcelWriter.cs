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
            MicrosoftExcel.Workbook excelWorkbook = excelApp.Workbooks.Add();
            MicrosoftExcel.Worksheet excelWorksheet = (MicrosoftExcel.Worksheet)excelWorkbook.Sheets.Add();   
            try
            {
                int i = 1;
                foreach (var cell in collection)
                {
                    excelWorksheet.Cells[i, columnNumber] = cell;
                }

                excelApp.ActiveWorkbook.SaveAs(outputFilePath, MicrosoftExcel.XlFileFormat.xlWorkbookNormal);

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
