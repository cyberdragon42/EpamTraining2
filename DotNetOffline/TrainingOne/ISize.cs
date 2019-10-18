using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingOne
{
    public interface ISize
    {
        double Width { get; set; }
        double Height { get; set; }
        void Perimeter();
    }
}
