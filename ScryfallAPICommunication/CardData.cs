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

        public double ConvertedManaCost;
        public string[] ColorIdentities;
        public string SpellType;
        #endregion

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
