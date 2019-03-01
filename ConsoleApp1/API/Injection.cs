using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class Injection
    {
        private IWriter _writer;

        public Injection(IWriter outputDestination)
        {
            _writer = outputDestination;
        }

        public void WriteOutput(string outputValue)
        {
            _writer.WriteOutput(outputValue);
        }
    }
}
