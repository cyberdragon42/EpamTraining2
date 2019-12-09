using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingExel
{
   public interface ICollectionWriter
   {
       void WriteCollections();
       void WriteCollectionsIntoFile();
       void WriteCollectionsOnConsole();
   }
}
