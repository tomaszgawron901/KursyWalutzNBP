using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Runtime.Serialization;

namespace KursyWalutzNBPClassLibrary
{
    [DataContract(Name = "pozycja", Namespace = "")]
    public class pozycja
    {
        [DataMember(Name = "nazwa_waluty", Order = 1)]
        public string name = "";

        [DataMember(Name = "przelicznik", Order = 2)]
        public int converter;

        [DataMember(Name = "kod_waluty", Order = 3)]
        public string currencyCode = "";

        [DataMember(Name = "kurs_kupna", Order = 4)]
        public string stringBuyingRate
        {
            get { return buyingRate.ToString(); }
            set
            {
                this.buyingRate = float.Parse(value);
            }
        }

        [DataMember(Name = "kurs_sprzedazy", Order = 5)]
        public string stringSellingRate
        {
            get { return sellingRate.ToString(); }
            set
            {
                this.sellingRate = float.Parse(value);
            }
        }

        public float buyingRate;
        public float sellingRate;


    }


    [CollectionDataContract(Name = "tabela_kursow", ItemName = "pozycja", Namespace = "")]
    class tabela_kursow: List<pozycja>
    {
        public static string[] availableCurrencyCodes = { "USD", "EUR", "CHF", "GBP" };

        public tabela_kursow()
            : base()
        {
        }

        public tabela_kursow(pozycja[] items)
            : base()
        {
            foreach (pozycja item in items)
            {
                Add(item);
            }
        }

        new public void Add(pozycja item)
        {
            if (availableCurrencyCodes.Contains(item.currencyCode))
                base.Add(item);
        }

        /// <summary>
        /// Returns first pozycja with given currencyCode.
        /// </summary>
        public pozycja getByCurrencyCode(string currencyCode)
        {
            foreach(pozycja p in this)
            {
                if (p.currencyCode == currencyCode) return p;
            }
            throw new KeyNotFoundException();
        }

        public float averageBuyingRate()
        {
            float sum = 0;
            foreach(pozycja p in this)
            {
                sum += p.buyingRate;
            }
            return sum / this.Count;
        }

        public float averagesellingRate()
        {
            float sum = 0;
            foreach (pozycja p in this)
            {
                sum += p.sellingRate;
            }
            return sum / this.Count;
        }

    }


}
