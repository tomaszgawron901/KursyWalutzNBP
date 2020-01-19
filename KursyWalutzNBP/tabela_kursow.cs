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
        public info dateInformation;

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
                this.buyingRate = double.Parse(value);
            }
        }

        [DataMember(Name = "kurs_sprzedazy", Order = 5)]
        public string stringSellingRate
        {
            get { return sellingRate.ToString(); }
            set
            {
                this.sellingRate = double.Parse(value);
            }
        }

        public double buyingRate;
        public double sellingRate;
    }


    [DataContract(Name = "tabela_kursow", Namespace = "")]
    public class info
    {
        [DataMember(Name = "data_publikacji")]
        public DateTime publicationDate;

        [DataMember(Name = "data_notowania")]
        public DateTime entryDate;
    }

   

}
