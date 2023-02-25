using HorseTrackConsoleApp.Data;
using HorseTrackConsoleApp.Interface;
using HorseTrackConsoleApp.ModelDTO;
using HorseTrackConsoleApp.StaticData;
using System.Collections.Generic;
using System.Linq;

namespace HorseTrackConsoleApp.Provider
{
    public class MoneyProvider :singleton<MoneyProvider>, IMoneyProvider
    {
        private MoneyProvider() { }
        public new static MoneyProvider Instance
        {
            get
            {
                MoneyProvider.initializer(() =>
                {
                    return new MoneyProvider();
                });
                return singleton<MoneyProvider>.Instance;
            }
        }
        /// <summary>
        /// reset the initial stock
        /// </summary>
        public void Restock()
        {
            try
            {
                MoneyDenominationList.Instance.GetMoneyList();
            }
            catch { }
        }

        public void payHorse(Horse horse)
        {
            try
            {
                if (horse.IsWin)
                {
                    if (BetList.betlsts != null)
                    {
                        List<Bet> bets = BetList.betlsts.Where(x => x.HourseId == horse.Hid).ToList();
                        foreach (Bet bet in bets)
                        {
                            PayDTO payDTO = BetProvider.Instance.payByBet(bet);
                            if (payDTO.isSuccess)
                                OutputProvider.Instance.ShowPaySuccess(payDTO);
                            else
                                OutputProvider.Instance.ShowPayFail(payDTO);
                        }
                    }
                }
                else
                    OutputProvider.Instance.ShowNoPayout(horse);
            }
            catch { }
        }

        public void payBet(Bet bet)
        {
            try
            {
                Horse horse = null;
                if (bet != null)
                {
                    if (HorseList.horselsts == null || HorseList.horselsts.Count == 0)
                        horse = HorseList.Instance.getHorseList().Where(x => x.Hid == bet.HourseId).FirstOrDefault();
                    else
                        horse = HorseList.horselsts.Where(x => x.Hid == bet.HourseId).FirstOrDefault();
                    payHorse(horse);
                    BetList.betlsts.Remove(bet);
                }
            }
            catch { }
        }
    }
}
