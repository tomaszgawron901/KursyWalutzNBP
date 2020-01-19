using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursyWalutzNBPClassLibrary
{
    static public class Statistics
    {
        public static (
            double averageSellingRate,
            double averageBuyingTare,
            double sellingRateStandardDeviation,
            double buyingRateStandardDeviation,
            List<pozycja> minimumSellingRatePozycja,
            List<pozycja> maximumSellingRatePozycja,
            List<pozycja> minimumBuyingRatePozycja,
            List<pozycja> maximumBuyingRatePozycja) getInfo(this List<pozycja> pozycje)
        {
            if (pozycje.Count == 0 || pozycje is null)
            {
                throw new Exception("Nothing to write info about.");
            }
            double sumOfSellingRate = pozycje[0].sellingRate;
            double sumOfBuyingRate = pozycje[0].buyingRate;

            List<pozycja> minimumSellingRatePozycja = new List<pozycja>() { pozycje[0] };
            List<pozycja> maximumSellingRatePozycja = new List<pozycja>() { pozycje[0] };

            List<pozycja> minimumBuyingRatePozycja = new List<pozycja>() { pozycje[0] };
            List<pozycja> maximumBuyingRatePozycja = new List<pozycja>() { pozycje[0] };

            for(int i = 1; i < pozycje.Count; i++)
            {
                pozycja poz = pozycje[i];
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
                maximumBuyingRatePozycja);
        }

    }
}
