using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingEnums
{
    public interface ISize
    {
        double Width { get; set; }
        double Height { get; set; }
        double Perimeter();
    }
}
