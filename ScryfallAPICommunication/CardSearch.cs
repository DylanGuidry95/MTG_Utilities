using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScryfallAPICommunication
{
    public class CardSearch
    {
        public static async Task<Dictionary<string, dynamic>> SearchCardBySetID(string set_code, string number)
        {
            var response = await ApiCommunication.instance.FetchFromBackEnd($"cards/{set_code}/{number}");
            return response;
        }

        public static async Task<Dictionary<string, dynamic>> SearchCardByMultiverseID(string multiverse_number)
        {
            var response = await ApiCommunication.instance.FetchFromBackEnd($"cards/multiverse/{multiverse_number}");
            return response;
        }

        public static async Task<Dictionary<string, dynamic>> SearchCardByMtgoID(string number)
        {
            var response = await ApiCommunication.instance.FetchFromBackEnd($"cards/mtgo/{number}");
            return response;           
        }

        public static async Task<Dictionary<string, dynamic>> SearchCardByArenaID(string number)
        {
            var response = await ApiCommunication.instance.FetchFromBackEnd($"cards/arena/{number}");
            return response;
        }

        public static async Task<Dictionary<string, dynamic>> SearchCardByTcgPlayerID(string number)
        {
            var response = await ApiCommunication.instance.FetchFromBackEnd($"cards/tcgplayer/{number}");
            return response;
        }

        public static async Task<Dictionary<string, dynamic>> SearchCardByCardMarketID(string number)
        {
            var response = await ApiCommunication.instance.FetchFromBackEnd($"cards/cardmarket/{number}");
            return response;
        }

        public static async Task<Dictionary<string, dynamic>> SearchCardByID(string oracle_id)
        {
            var response = await ApiCommunication.instance.FetchFromBackEnd($"cards/{oracle_id}");
            return response;
        }

        public static async Task<Dictionary<string, dynamic>> AutoCompleteCardName(string name)
        {
            var response = await ApiCommunication.instance.FetchFromBackEnd($"cards/autocomplete?q={name}");
            return response;
        }
    }
}
