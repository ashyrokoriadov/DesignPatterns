using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.FileWriter
{
    public interface IFileWriter
    {
        bool Write(IEnumerable<string> contents);
    }
}
