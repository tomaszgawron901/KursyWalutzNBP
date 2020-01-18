using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KursyWalutzNBPClassLibrary;

namespace NBPConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            ReaderNBP reader = new ReaderNBP();
            var dn = reader.readDataNames(new DateTime(2010, 1, 2), new DateTime(2012, 1, 3));
            reader.readTable("c025z100205", "EUR");
        }
    }
}
