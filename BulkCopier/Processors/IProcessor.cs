using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkCopier.Processors
{
    interface IProcessor
    {
        Task ProcessItem(string id);
        Task ProcessCollection();
    }
}
