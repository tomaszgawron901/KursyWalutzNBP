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
        static (
            double averageSellingRate,
            double averageBuyingTare,
            double sellingRateStandardDeviation,
            double buyingRateStandardDeviation,
            List<pozycja> minimumSellingRatePozycja,
            List<pozycja> maximumSellingRatePozycja,
            List<pozycja> minimumBuyingRatePozycja,
            List<pozycja> maximumBuyingRatePozycja) getInfo(List<pozycja> pozycje)
        {
            if(pozycje.Count == 0 || pozycje is null)
            {
                throw new Exception("Nothing to write info about.");
            }
            double sumOfSellingRate = 0;
            double sumOfBuyingRate = 0;

            List<pozycja> minimumSellingRatePozycja = new List<pozycja>(){ pozycje[0] };
            List<pozycja> maximumSellingRatePozycja = new List<pozycja>() { pozycje[0] };

            List<pozycja> minimumBuyingRatePozycja = new List<pozycja>() { pozycje[0] };
            List<pozycja> maximumBuyingRatePozycja = new List<pozycja>() { pozycje[0] };

            foreach (pozycja poz in pozycje)
            {
                sumOfSellingRate += poz.sellingRate;
                sumOfBuyingRate += poz.buyingRate;

                if (poz.sellingRate < minimumSellingRatePozycja[0].sellingRate)
                    minimumSellingRatePozycja = new List<pozycja> { poz };
                else if (poz.sellingRate == minimumSellingRatePozycja[0].sellingRate)
                    minimumSellingRatePozycja.Add(poz);

                if (poz.sellingRate > maximumSellingRatePozycja[0].sellingRate)
                    maximumSellingRatePozycja = new List<pozycja> { poz };
                else if (poz.sellingRate == maximumSellingRatePozycja[0].sellingRate)
                    maximumSellingRatePozycja.Add(poz);


                if (poz.buyingRate < minimumBuyingRatePozycja[0].buyingRate)
                    minimumBuyingRatePozycja = new List<pozycja> { poz };
                else if (poz.buyingRate == minimumBuyingRatePozycja[0].buyingRate)
                    minimumBuyingRatePozycja.Add(poz);

                if (poz.buyingRate > maximumBuyingRatePozycja[0].buyingRate)
                    maximumBuyingRatePozycja = new List<pozycja> { poz };
                else if (poz.buyingRate == maximumBuyingRatePozycja[0].buyingRate)
                    maximumBuyingRatePozycja.Add(poz);
            }

            double averageSellingRate = sumOfSellingRate / pozycje.Count;
            double averageBuyingTare = sumOfBuyingRate / pozycje.Count;

            double Es = 0; // sum of diference between average and current selling rate to the power of 2.
            double Eb = 0; // sum of diference between average and current buying rate to the power of 2.
            foreach (pozycja poz in pozycje)
            {
                Es += Math.Pow(poz.sellingRate - averageSellingRate, 2);
                Eb += Math.Pow(poz.buyingRate - averageBuyingTare, 2);
            }

            double sellingRateStandardDeviation = Math.Sqrt(Es / (pozycje.Count - 1));
            double buyingRateStandardDeviation = Math.Sqrt(Eb / (pozycje.Count - 1));

            return (
                averageSellingRate,
                averageBuyingTare,
                sellingRateStandardDeviation,
                buyingRateStandardDeviation,
                minimumSellingRatePozycja,
                maximumSellingRatePozycja,
                minimumBuyingRatePozycja,
                maximumBuyingRatePozycja) ;
        }


        static void Main(string[] args)
        {

            ReaderNBP reader = new ReaderNBP();
            var dn = reader.readListOfPozycja(new DateTime(2010, 1, 2), new DateTime(2011, 1, 3), "EUR");
            var sd = getInfo(dn);
        }
    }
}
