using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace KursyWalutzNBPClassLibrary
{
    public class ReaderNBP
    {
        private static DateTime firstDataDate = new DateTime(2002, 1, 1);
        private static string path = "http://www.nbp.pl/kursy/xml/";


        public List<string> readDataNames(DateTime firstDate, DateTime lastDate)
        {
            if (firstDate.Year < firstDataDate.Year) firstDate = firstDataDate;
            if (lastDate.Year > DateTime.Now.Year) lastDate = DateTime.Now;

            WebClient client = new WebClient();
            List<string> stringFileNames = new List<string>();
            Stream stream;
            for (int year = firstDate.Year; year<= lastDate.Year; year++)
            {
                
                try
                {
                    stream = client.OpenRead($"{path}dir{year}.txt");
                }catch(System.Net.WebException e)
                {
                    if (e.Status == WebExceptionStatus.ProtocolError)
                        continue;
                    else
                    {
                        throw e;
                    }
                }
                catch
                {
                    continue;
                }
                StreamReader reader = new StreamReader(stream);

                for(string line = reader.ReadLine(); !(line is null); line = reader.ReadLine())
                {
                    var date = parseToDate(line.Substring(line.Length - 6));
                    if (line.StartsWith("c") && date>=firstDate && date <= lastDate)
                    {
                        stringFileNames.Add(line);
                    }
                }
            }
            return stringFileNames;
        }

        public pozycja readPozycja(string path, string currencyCode)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load($"{ReaderNBP.path}{path}.xml");
            var reader = new XmlTextReader(new StringReader(xmlDoc.OuterXml));
            DataContractSerializer serializer = new DataContractSerializer(typeof(info));
            var information = (info)serializer.ReadObject(reader, true);

            foreach (XmlNode child in xmlDoc.DocumentElement.ChildNodes)
            {
                if(child.Name == "pozycja")
                {
                    reader = new XmlTextReader(new StringReader(child.OuterXml));
                    serializer = new DataContractSerializer(typeof(pozycja));
                    var poz = (pozycja)serializer.ReadObject(reader, true);
                    if(poz.currencyCode == currencyCode)
                    {
                        poz.dateInformation = information;
                        return poz;
                    }
                }
            }
            throw new Exception("Pzoycja not found.");
        }

        public List<pozycja> readListOfPozycja(DateTime firstDate, DateTime lastDate, string currencyCode)
        {
            List<pozycja> output = new List<pozycja>();
            foreach (var path in readDataNames(firstDate, lastDate))// Can throw an Exception.
            {
                output.Add(readPozycja(path, currencyCode));// Can throw an Exception.
            }
            return output;
        }


        private string parseToString(DateTime date)
        {
            return string.Format("{0:yyMMdd}", date);
        }

        private DateTime parseToDate(string date)
        {
            return DateTime.Parse($"20{date[0]}{date[1]}-{date[2]}{date[3]}-{date[4]}{date[5]}");
        }


    }
}
