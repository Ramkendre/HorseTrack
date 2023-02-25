using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackConsoleApp.Data
{
   public class Bet
    {
        public int Bid { get; set; }
        public int Betamount { get; set; }
        public int HourseId { get; set; }
       // public Horse Horse { get; set; }
        public Bet() { }
        public Bet(int bid,int betamount,int hourseId)
        {
            Bid = bid;
            Betamount = betamount;
            HourseId = hourseId;
        }
    }
}
