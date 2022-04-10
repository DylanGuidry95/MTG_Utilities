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
        public string ScryfallId;
        public string Language;
        public long TCGPlayerId;
        public long CardMarketId;
        public long ArenaId;
        public string MultiverseId;
        public long MtgoId;
        #endregion

        #region Card Gameplay Fields        
        public string Keywords;        
        public double ConvertedManaCost;
        public string Colors;
        #endregion

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
