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
            reader.read(new DateTime(1999, 1, 1), DateTime.Now);
        }
    }
}
