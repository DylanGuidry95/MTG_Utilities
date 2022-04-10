using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScryfallAPICommunication
{
    public class CardImageSearch
    {
        public static async Task<string> SearchCardImage(string set_id, string printing_number)
        {
            var data = await CardSearch.SearchCardBySetID(set_id, printing_number);
            var imageLink = data["image_uris"];
            return imageLink["png"];
        }
    }
}
