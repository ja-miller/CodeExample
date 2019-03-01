using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public enum OutputWriters { console, database };
    public class Factory
    {
        public void WriteOutput(OutputWriters outputDestination, string outputValue)
        {
            IWriter writer = GetWriter(outputDestination);
            writer.WriteOutput(outputValue);
        }

        private IWriter GetWriter(OutputWriters outputDestination)
        {
            switch (outputDestination)
            {
                case OutputWriters.database:
                    {
                        return new DBWriter();
                    }
                default:
                    {
                        return new ConsoleWriter();
                    }
            }
        }
    }
}
