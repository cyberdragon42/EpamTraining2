using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingFour
{
    public interface ILogger
    {
        void Read();
        void Write(string message);
    }
}
