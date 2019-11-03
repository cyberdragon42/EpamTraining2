using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ServiceClasses;
using System.Configuration;

namespace Reflection
{
    public class AssemblyInspector
    {
        private string AssemblyPath;
        IPrinter Printer;

        public AssemblyInspector(IPrinter printer)
        {
            try
            {
                AssemblyPath = ConfigurationSettings.AppSettings["targetAssembly"];
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DisplayAssemblyInfo()
        {
            try
            {
                Assembly targetAssembly = Assembly.LoadFrom(AssemblyPath);
                Type[] targetAssemblyTypes = targetAssembly.GetExportedTypes();
                Printer.Print(targetAssembly.FullName);
                foreach (var type in targetAssemblyTypes)
                {
                    Printer.Print(type.Name);
                    Printer.Print("methods: ");
                    foreach (var methods in type.GetMethods())
                    {
                        Printer.Print(methods.Name);
                    }

                    Printer.Print("fields: ");
                    foreach (var fields in type.GetFields())
                    {
                        Printer.Print(fields.Name);
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
