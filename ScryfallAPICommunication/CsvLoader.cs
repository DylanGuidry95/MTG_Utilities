using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChoETL;

namespace ScryfallAPICommunication
{
    public class CsvLoader
    {
        public static List<CardData> LoadFromCSV(string csvPath)
        {
            var cards = new List<CardData>();
            using (var reader = new ChoCSVReader(csvPath).WithFirstLineHeader())
            {
                foreach (dynamic item in reader)
                {
                    var newCard = new CardData()
                    {
                        Name = item.Name,
                        PrintingNumber = item.CardNumber,
                        SetCode = item.SetCode
                    };
                    cards.Add(newCard);
                }
            }
            return cards;
        }
    }
}
