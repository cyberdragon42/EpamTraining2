using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceClasses;
using TrainingDirectories;

namespace EpamTraining2
{
    public class DirectoriesRunner: IRunner
    {
        ILogger Logger;
        public DirectoriesRunner()
        {
            Logger = new TextFileLogger();
        }
        public void Run()
        {
            try
            {
                RunTaskVisualiseDirectory();
                RunTaskSearchMatchingFiles();
            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Logger.Log(e.Message);
            }
        }

        public void RunTaskVisualiseDirectory()
        {
            Console.WriteLine("____________Task Directory Visualiser____________");
            DirectoryVisualizer directoryVisualiser = new DirectoryVisualizer(new ConsolePrinter());
            directoryVisualiser.VisualizeDirectory();
        }

        public void RunTaskSearchMatchingFiles()
        {
            Console.WriteLine("____________Task Matching Files Searcher____________");
            FileSearcher fileSearcher = new FileSearcher(new ConsolePrinter());
            Console.WriteLine("Please, enter fragment of file name: ");
            string nameFromConsole = Console.ReadLine();
            fileSearcher.SearchMatchingFiles(nameFromConsole);
        }
    }
}
