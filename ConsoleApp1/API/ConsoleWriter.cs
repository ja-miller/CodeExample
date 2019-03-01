using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class ConsoleWriter : IWriter
    {
        public void WriteOutput(string OutputValue)
        {
            Console.WriteLine(OutputValue);
        }
    }
}
