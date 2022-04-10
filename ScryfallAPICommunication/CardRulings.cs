using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScryfallAPICommunication
{
    public class CardRulings
    {
        public static async Task<Dictionary<string, dynamic>> SearchCardRulingSetPrinting(string set_code, string number)
        {
            var response = await ApiCommunication.instance.FetchFromBackEnd($"cards/{set_code}/{number}/rulings");
            return response;
        }

        public static async Task<Dictionary<string, dynamic>> SearchCardRulingAllPrinting(string multiverse_number)
        {
            var response = await ApiCommunication.instance.FetchFromBackEnd($"cards/multiverse/{multiverse_number}/rulings");
            return response;
        }

        public static async Task<Dictionary<string, dynamic>> SearchCardRulingByMtgo(string number)
        {
            var response = await ApiCommunication.instance.FetchFromBackEnd($"cards/mtgo/{number}/rulings");
            return response;
        }

        public static async Task<Dictionary<string, dynamic>> SearchCardRulingByArena(string number)
        {
            var response = await ApiCommunication.instance.FetchFromBackEnd($"cards/arena/{number}/rulings");
            return response;
        }

        public static async Task<Dictionary<string, dynamic>> SearchCardRulingById(string oracle_id)
        {
            var response = await ApiCommunication.instance.FetchFromBackEnd($"cards/{oracle_id}/rulings");
            return response;
        }
    }
}
