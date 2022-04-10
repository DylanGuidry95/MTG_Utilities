using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScryfallAPICommunication
{
    public class PriceSearch
    {
        public static async Task<Newtonsoft.Json.Linq.JObject> GetTcgPlayerPrice(string set_id, string printing_number)
        {
            var carddata = await CardSearch.SearchCardBySetID(set_id, printing_number);
            var id = carddata["tcgplayer_id"].ToString();
            var price_data = await CardSearch.SearchCardByTcgPlayerID(id);
            return price_data["prices"];
        }

        public static async Task<Newtonsoft.Json.Linq.JObject> GetCardMarketPrice(string set_id, string printing_number)
        {
            var carddata = await CardSearch.SearchCardBySetID(set_id, printing_number);
            var id = carddata["cardmarket_id"].ToString();
            var price_data = await CardSearch.SearchCardByTcgPlayerID(id);
            return price_data["prices"];
        }
    }
}
