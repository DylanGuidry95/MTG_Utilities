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
            var data = await ScryfallAPICommunication.CardSearch.AutoCompleteCardName("breed");
            foreach(var kvp in data)
            {
                Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
            }
            Console.ReadLine();            
        }
    }
}
