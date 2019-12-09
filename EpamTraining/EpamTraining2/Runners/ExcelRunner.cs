using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingExel;
using ServiceClasses;

namespace EpamTraining2
{
    public class ExcelRunner:IRunner
    {
        ILogger Logger;
        public ExcelRunner()
        {
            Logger = new TextFileLogger();
        }
        public void Run()
        {
            try
            {
                RunTaskListsFromExcel();
                RunTaskExcelDirectory();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Logger.Log(e.Message);
            }
        }

        public void RunTaskListsFromExcel()
        {
            Console.WriteLine("____________Task Excel Collections Displayer____________");
            ExcelCollectionDisplayer excelCollectionDisplayer = new ExcelCollectionDisplayer();
            excelCollectionDisplayer.ReadCollections();
            excelCollectionDisplayer.WriteCollections();
        }

        public void RunTaskExcelDirectory()
        {
            Console.WriteLine("____________Task Directory Excel Displayer____________");
            DirectoryCollectionDisplayer directoryCollectionDisplayer = new DirectoryCollectionDisplayer();
            directoryCollectionDisplayer.ReadCollections();
            directoryCollectionDisplayer.GetUniqueValues();
            directoryCollectionDisplayer.GetDouplicates();
            directoryCollectionDisplayer.WriteCollections();
        }
    }
}
