using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using KursyWalutzNBPClassLibrary;

namespace NBPWindowsFormsApp
{
    public partial class Form1 : Form
    {
        public bool searching = false;

        public async Task searchAndWriteInfoAsync()
        {
            if (searching) return;
            outputArea.Clear();
            try
            {
                if (currencyCodeInput.SelectedItem is null)
                    throw new ArgumentException("Nie wybrano kodu waluty.");

                string currencyCode = currencyCodeInput.SelectedItem.ToString();
                DateTime firstDate = dateInput1.Value;
                DateTime lastDate = dateInput2.Value;
                if (firstDate > lastDate) throw new ArgumentException("Początkowa data jest więkasz od daty końcowej.");


                             
                onSearchStart();
                outputArea.WriteLine("Pobieranie danych...");
                ReaderNBP reader = new ReaderNBP();
                var info = await Task.Run(()=> reader.readListOfPozycja(firstDate, lastDate, currencyCode));

                writeInfo(await Task.Run(info.getInfo));
            }
            catch (ArgumentException e)
            {
                outputArea.WriteLine(e.Message);
                outputArea.WriteLine("Spróbuj ponownie.");
            }
            catch (System.Net.WebException)
            {
                outputArea.WriteLine("Nieudało się pobrać danych. Spróbuj ponownie później.");
            }
            catch
            {
                outputArea.WriteLine("Nieznany błąd. Przepraszamy, sróbuj ponownie.");
            }
            onSearchEnd();
        }





        private void onSearchStart()
        {
            searching = true;
            downloadButton.Enabled = false;
        }

        private void onSearchEnd()
        {
            downloadButton.Enabled = true;
            searching = false;
        }

        public string setCurrencyCode()
        {
            return currencyCodeInput.Text;
        }

        public DateTime setDateTime(string stringDate)
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


        public void writeInfo((
        double averageSellingRate,
        double averageBuyingTare,
        double sellingRateStandardDeviation,
        double buyingRateStandardDeviation,
        List<pozycja> minimumSellingRatePozycja,
        List<pozycja> maximumSellingRatePozycja,
        List<pozycja> minimumBuyingRatePozycja,
        List<pozycja> maximumBuyingRatePozycja) info)
        {
            outputArea.Clear();
            writeElement("Średni kurs sprzedaży: ", info.averageSellingRate);
            writeElement("Odchylenie standardowe kursu sprzdaży: ", info.sellingRateStandardDeviation);
            writeList($"Minimalna wartość kursu sprzedaży wynosiła {info.minimumSellingRatePozycja[0].sellingRate} w dniach", info.minimumSellingRatePozycja);
            writeList($"Maxymalna wartość kursu sprzedaży wynosiła {info.maximumSellingRatePozycja[0].sellingRate} w dniach", info.maximumSellingRatePozycja);
            outputArea.WriteLine();
            writeElement("Średni kurs kupna: ", info.averageBuyingTare);
            writeElement("Odchylenie standardowe kursu kupna: ", info.buyingRateStandardDeviation);
            writeList($"Minimalna wartość kursu kupna wynosiła {info.minimumBuyingRatePozycja[0].buyingRate} w dniach", info.minimumBuyingRatePozycja);
            writeList($"Maxymalna wartość kursu kupna wynosiła {info.maximumBuyingRatePozycja[0].buyingRate} w dniach", info.maximumBuyingRatePozycja);
            outputArea.WriteLine();
        }

        private void writeElement(string introduction, double number)
        {
            outputArea.WriteLine(introduction + string.Format("{0:0.0000}", number));
        }

        private void writeList(string introduction, List<pozycja> lista)
        {
            outputArea.Write(introduction);
            foreach (pozycja poz in lista)
            {
                outputArea.Write(string.Format(" {0:yyyy-MM-dd}", poz.dateInformation.publicationDate));
            }
            outputArea.WriteLine();
        }


        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (searching) return;
            await searchAndWriteInfoAsync();


        }
    }
}
