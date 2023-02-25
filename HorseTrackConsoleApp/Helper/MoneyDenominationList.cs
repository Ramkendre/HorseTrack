using HorseTrackConsoleApp.Data;
using HorseTrackConsoleApp.Interface;
using System.Collections.Generic;
using System.Linq;

namespace HorseTrackConsoleApp.StaticData
{
    public class MoneyDenominationList : singleton<MoneyDenominationList>
    {
        private MoneyDenominationList() { }
        public new static MoneyDenominationList Instance
        {
            get
            {
                MoneyDenominationList.initializer(() =>
                {
                    return new MoneyDenominationList();
                });
                return singleton<MoneyDenominationList>.Instance;
            }
        }
        public List<Money> moneylst = new List<Money>();
        public static List<Money> moneylsts;

        public List<Money> GetMoneyList()
        {
            moneylst.Clear();
            moneylst.Add(new Money() { Mid = 1, Denomination = 1, Inventory = 10 });
            moneylst.Add(new Money() { Mid = 2, Denomination = 5, Inventory = 10 });
            moneylst.Add(new Money() { Mid = 3, Denomination = 10, Inventory = 10 });
            moneylst.Add(new Money() { Mid = 4, Denomination = 20, Inventory = 10 });
            moneylst.Add(new Money() { Mid = 5, Denomination = 100, Inventory = 10 });
            return moneylst;
        }

        public void addUpdateMoneyList(List<Money> moneys,Money money)
        {
            try
            {
                moneys.Where(x => x.Mid == money.Mid).FirstOrDefault().Inventory = money.Inventory;
                moneylsts = moneys;
            }
            catch { }
        }
    }
}
