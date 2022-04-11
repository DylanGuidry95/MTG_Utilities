using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTG_Assisstant
{


    class Program
    {        
        static void Main(string[] args)
        {            
            Data().GetAwaiter().GetResult();
        }

        static async Task Data()
        {
            ScryfallAPICommunication.ApiCommunication newCom = new ScryfallAPICommunication.ApiCommunication("https://api.scryfall.com");
            var data = await ScryfallAPICommunication.CsvLoader.LoadFromCSV(@"C:\Users\guidr\source\repos\MTG_Assisstant\kagicol.csv");            
            foreach (var d in data)
            {
                Console.WriteLine(d.ToString() + "\n");
            }
            Console.ReadLine();            
        }
    }
}
