using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingReflection;
using ServiceClasses;

namespace EpamTraining2
{
    public class ReflectionRunner: IRunner
    {
        ILogger Logger;
        public ReflectionRunner()
        {
            Logger = new TextFileLogger();
        }
        public void Run()
        {
            try
            {
                Console.WriteLine("____________Task Reflection____________");
                AssemblyInspector assemblyInspector = new AssemblyInspector(new ConsolePrinter());
                assemblyInspector.DisplayAssemblyInfo();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Logger.Log(e.Message);
            }
        }
    }
}
