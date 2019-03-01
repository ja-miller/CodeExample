using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class DBWriter : IWriter
    {
        public void WriteOutput(string OutputValue)
        {
            // db save/update implementation
            Console.WriteLine($"Saved value({OutputValue}) to db.");
        }
    }
}
