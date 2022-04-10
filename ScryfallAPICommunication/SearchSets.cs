using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScryfallAPICommunication
{
    public class SearchSets
    {
        public static async Task<Dictionary<string, dynamic>> SetData(string set_code)
        {
            var response = await ApiCommunication.instance.FetchFromBackEnd($"sets/{set_code}");
            return response;
        }
    }
}
