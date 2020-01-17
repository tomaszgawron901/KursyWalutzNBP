using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace KursyWalutzNBPClassLibrary
{
    public class ReaderNBP
    {
        private enum currency {USD, EUR, CHF, GBP}
        private static string path = "http://www.nbp.pl/kursy/xml/";


        public void read(DateTime firstDate, DateTime lastDate)
        {
            WebClient client = new WebClient();
            string stringFileNames = "";
            for(int year = firstDate.Year; year<= lastDate.Year; year++)
            {
                Stream stream;
                try
                {
                    stream = client.OpenRead($"{path}dir{year}.txt");
                }catch
                {
                    continue;
                }
                StreamReader reader = new StreamReader(stream);
                stringFileNames += "\r\n"+reader.ReadToEnd();
            }
            var f = stringFileNames.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                .Where(filename => filename != "" && filename[0] == 'c');

        }

        private string parseToString(DateTime date)
        {
            return string.Format("{0:yyMMdd}", date);
        }


    }
}
