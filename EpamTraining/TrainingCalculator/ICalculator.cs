using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCalculator
{
    public interface ICalculator
    {
        double Calculation(double x, double y, char op);
        void WriteResult();
        bool ReadInput();
        void ExecuteCalculation();
    }
}
