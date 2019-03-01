using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // examples of using explicit definitions of IWriter classes
            var writers = new ExplicitDef();
            writers.UseConsoleWriter("Hello World.");
            Console.ReadLine();

            writers.UseDBWriter("Hello World.");
            Console.ReadLine();

            // Class factory example
            var factory = new Factory();
            factory.WriteOutput(OutputWriters.console, "Hello World.");
            Console.ReadLine();

            factory.WriteOutput(OutputWriters.database, "Hello World.");
            Console.ReadLine();

            // DI example
            var i = new Injection(new ConsoleWriter());
            i.WriteOutput("Hello World.");
            Console.ReadLine();

            var d = new Injection(new DBWriter());
            d.WriteOutput("Hello World.");
            Console.ReadLine();
        }
    }
}
