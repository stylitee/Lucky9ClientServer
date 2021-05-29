using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServerGame.Model
{
    public class Player
    {
        public int id { get; set; }
        public string playerName { get; set; }
        public string card_values { get; set; }
        public string UpForSteal { get; set; }
        public string isReady { get; set; }
    }
}
