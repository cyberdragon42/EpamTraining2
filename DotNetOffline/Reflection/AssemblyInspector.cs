using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace Reflection
{
    public class AssemblyInspector
    {
        private string AssemblyPath;

        public AssemblyInspector(string assemblyPath)
        {
            AssemblyPath = assemblyPath;
        }

        public void DisplayAssemblyInfo()
        {
            Assembly targetAssembly = Assembly.LoadFrom(AssemblyPath);
            Type[] targetAssemblyTypes = targetAssembly.GetExportedTypes();
            foreach(var type in targetAssemblyTypes)
            {
                Console.WriteLine();
                Console.WriteLine(type.Name);
                Console.WriteLine("methods: ");

                foreach (var methods in type.GetMethods())
                {
                    Console.WriteLine(methods.Name);
                }
                Console.WriteLine("fields: ");

                foreach (var fields in type.GetFields())
                {
                    Console.WriteLine(fields.Name);
                }
            }
        }
    }
}
