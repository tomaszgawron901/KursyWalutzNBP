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
        static class Controller
        {
            private static string[] availableCurrencyCodes = new string[]{ "USD", "EUR", "CHF", "GBP" };


            public static void start()
            {
                do
                {
                    while(true)
                    {
                        Console.WriteLine("Podaj kod waluty, datę początkową i datę końcową (np: EUR 2018-09-01 2018-09-20) ");
                        try
                        {
                            string[] inputs = Console.ReadLine().Split(' ').Where(input => input != "" && input != null).ToArray();
                            if(inputs.Length != 3)
                            {
                                throw new ArgumentException("Nieprawidłowy ciąg znaków.");
                            }

                            string currencyCode = setCurrencyCode(inputs[0]);
                            DateTime firstDate = setDateTime(inputs[1]);
                            DateTime lastDate = setDateTime(inputs[2]);
                            if (firstDate > lastDate) throw new ArgumentException("Początkowa data jest więkasz od daty końcowej.");
                            ReaderNBP reader = new ReaderNBP();
                            Console.WriteLine("Pobieranie danych...");
                            writeInfo(reader.readListOfPozycja(firstDate, lastDate, currencyCode).getInfo());

                            break;
                        }
                        catch(ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Spróbuj ponownie.");
                        }catch(System.Net.WebException)
                        {
                            Console.WriteLine("Nieudało się pobrać danych. Spróbuj ponownie później.");
                        }
                        catch
                        {
                            Console.WriteLine("Nieznany błąd. Przepraszamy, sróbuj ponownie.");
                        }
                    }


                } while (confirming("Czy chcesz kontynuować (T/N)?", 'T'));
            }


            private static bool confirming(string notification, char c)
            {
                Console.Write(notification);
                c = char.ToUpper(c);
                var key = Console.ReadKey();
                Console.WriteLine();
                return char.ToUpper(key.KeyChar) == c;

            }

            public static string setCurrencyCode(string code)
            {
                code = code.ToUpper();
                if (!Controller.availableCurrencyCodes.Contains(code))
                    throw new ArgumentException("Niewłaściwy kod waluty. Dostępne kody waluty to: USD, EUR, CHF, GBP.");
                return code;
            }

            public static DateTime setDateTime(string stringDate)
            {
                DateTime date;
                try
                {
                    date = DateTime.Parse(stringDate);
                }
                catch
                {
                    throw new ArgumentException("Niewłaciwie podana data.");
                }
                return date;
            }


            public static void writeInfo((
            double averageSellingRate,
            double averageBuyingTare,
            double sellingRateStandardDeviation,
            double buyingRateStandardDeviation,
            List<pozycja> minimumSellingRatePozycja,
            List<pozycja> maximumSellingRatePozycja,
            List<pozycja> minimumBuyingRatePozycja,
            List<pozycja> maximumBuyingRatePozycja) info)
            {
                Console.WriteLine();
                writeElement("Średni kurs sprzedaży: ", info.averageSellingRate);
                writeElement("Odchylenie standardowe kursu sprzdaży: ", info.sellingRateStandardDeviation);
                writeList($"Minimalna wartość kursu sprzedaży wynosiła {info.minimumSellingRatePozycja[0].sellingRate} w dniach", info.minimumSellingRatePozycja);
                writeList($"Maxymalna wartość kursu sprzedaży wynosiła {info.maximumSellingRatePozycja[0].sellingRate} w dniach", info.maximumSellingRatePozycja);
                Console.WriteLine();
                writeElement("Średni kurs kupna: ", info.averageBuyingTare);
                writeElement("Odchylenie standardowe kursu kupna: ", info.buyingRateStandardDeviation);
                writeList($"Minimalna wartość kursu kupna wynosiła {info.minimumBuyingRatePozycja[0].buyingRate} w dniach", info.minimumBuyingRatePozycja);
                writeList($"Maxymalna wartość kursu kupna wynosiła {info.maximumBuyingRatePozycja[0].buyingRate} w dniach", info.maximumBuyingRatePozycja);
                Console.WriteLine();
            }

            private static void writeElement(string introduction, double number)
            {
                Console.WriteLine(introduction + string.Format("{0:0.0000}", number));
            }

            private static void writeList(string introduction, List<pozycja> lista)
            {
                Console.Write(introduction);
                foreach(pozycja poz in lista)
                {
                    Console.Write(string.Format(" {0:yyyy-MM-dd}", poz.dateInformation.publicationDate));
                }
                Console.WriteLine();
            }


        }


        static void Main(string[] args)
        {

            Controller.start();
        }
    }
}
