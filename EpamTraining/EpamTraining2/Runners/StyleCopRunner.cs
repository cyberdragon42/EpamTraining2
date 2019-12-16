using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingStyleCop;
using ServiceClasses;

namespace EpamTraining2
{
    public class StyleCopRunner:IRunner
    {
        ILogger Logger;
        public StyleCopRunner()
        {
            Logger = new TextFileLogger();
        }

        public void Run()
        {
            try
            {
                Console.WriteLine("____________Task StyleCopRectangle____________");
                Rectangle rectangle = new Rectangle(new Point(0, 5), new Point(9, 1));
                Console.WriteLine("New rectangle: ");
                rectangle.ShowRectangle();
                rectangle.Resize(2);
                Console.WriteLine("Rectangle after resize: ");
                rectangle.ShowRectangle();
                Console.WriteLine("Rectangle after relocation: ");
                rectangle.Move(new Point(0, 3));
                rectangle.ShowRectangle();
                Rectangle rectangleToUnite = new Rectangle(new Point(15, 10), new Point(20, 1));
                Console.WriteLine("Union rectangle: ");
                Rectangle unitedRectangle = rectangle.BuildUnionRectangle(rectangleToUnite);
                unitedRectangle.ShowRectangle();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Logger.Log(e.Message);
            }
        }
    }
}
