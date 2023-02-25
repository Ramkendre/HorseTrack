using HorseTrackConsoleApp.Data;
using HorseTrackConsoleApp.Interface;
using System.Collections.Generic;

namespace HorseTrackConsoleApp.StaticData
{
   public class BetList : singleton<BetList>
    {
        private BetList() { }
        public new static BetList Instance
        {
            get
            {
                BetList.initializer(() =>
                {
                    return new BetList();
                });
                return singleton<BetList>.Instance;
            }
        }
        public List<Bet> betlst = new List<Bet>();
        public static List<Bet> betlsts;
      
        public void AddBets(Bet bet)
        {
            try
            {
                betlst.Add(bet);
                betlsts = betlst;
            }
            catch { }
        }
    }
}
