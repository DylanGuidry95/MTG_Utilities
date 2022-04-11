using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChoETL;
using Microsoft.VisualBasic.FileIO;

namespace ScryfallAPICommunication
{
    public class CsvLoader
    {
        public async static Task<List<CardData>> LoadFromCSV(string csvPath)
        {
            var cards = new List<CardData>();
            var parser = new TextFieldParser(csvPath);

            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");
            
            while(!parser.EndOfData)
            {
                var line = parser.ReadFields();
                if (line[0] == "Quantity")
                    continue;
                var newCard = new CardData()
                {
                    Name = line[1],
                    PrintingNumber = line[4],
                    SetCode = line[5]
                };                
                var data = await CardSearch.SearchCardBySetID(newCard.SetCode.ToLower(), newCard.PrintingNumber);
                newCard.ConvertedManaCost = data["cmc"];
                newCard.ColorIdentities = data["colors"].ToObject(typeof(string[]));
                newCard.SpellType = data["type_line"];
                cards.Add(newCard);
            }
            return cards;
        }
    }
}
