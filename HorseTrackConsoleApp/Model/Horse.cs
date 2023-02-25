using HorseTrackConsoleApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackConsoleApp.Data
{
    public class Horse
    {
        public int Hid { get; set; }
        public string Name { get; set; }
        public int Odds { get; set; }
        public bool IsWin { get; set; }
        public Horse()
        {

        }
        public Horse(int id,string name,int odds,bool iswin)
        {
            Hid = id;
            Name = name;
            Odds = odds;
            IsWin = iswin;
        }

        public string toString()
        {
            return Hid + "," + Name + "," + Odds + "," + ((IsWin) ? HelperMessages.Won_msg : HelperMessages.Lost_msg);
        }
    }
}
