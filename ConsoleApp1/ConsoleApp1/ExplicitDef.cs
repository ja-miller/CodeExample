using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API;

namespace ConsoleApp1
{
    class ExplicitDef
    {
        public void UseConsoleWriter(string outputValue)
        {
            IWriter consoleWriter = new ConsoleWriter();
            consoleWriter.WriteOutput(outputValue);
        }

        public void UseDBWriter(string outputValue)
        {
            IWriter dbWriter = new DBWriter();
            dbWriter.WriteOutput(outputValue);
        }
    }
}
