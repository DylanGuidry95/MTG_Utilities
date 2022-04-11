using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScryfallAPICommunication
{
    public class CardData
    {
        #region Card Id Fields
        public string Name;
        public string SetCode;
        public string PrintingNumber;
        #endregion

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
