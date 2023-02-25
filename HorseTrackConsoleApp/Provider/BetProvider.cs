using HorseTrackConsoleApp.Data;
using HorseTrackConsoleApp.Interface;
using HorseTrackConsoleApp.ModelDTO;
using HorseTrackConsoleApp.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HorseTrackConsoleApp.Provider
{
    public class BetProvider : singleton<BetProvider>,IBetProvider
    {
        private BetProvider() { }
        public new static BetProvider Instance
        {
            get
            {
                BetProvider.initializer(() =>
                {
                    return new BetProvider();
                });
                return singleton<BetProvider>.Instance;
            }
        }

        int amountOfBills = 0;
        public Bet addBet(int horseId, int value)
        {
            Bet bet = new Bet();
            bet.HourseId = horseId;
            bet.Betamount = value;

            BetList.Instance.AddBets(bet);
            return bet;
        }

        public PayDTO payByBet(Bet bet)
        {
            Horse horse = null;
            List<Money> moneys = null;
            if (HorseList.horselsts == null || HorseList.horselsts.Count == 0)
                horse = HorseList.Instance.getHorseList().Where(x => x.Hid == bet.HourseId).FirstOrDefault();
            else
                horse = HorseList.horselsts.Where(x => x.Hid == bet.HourseId).FirstOrDefault();
            // calcluated win amount
            int mustPaySum = bet.Betamount * horse.Odds;
            if (MoneyDenominationList.moneylsts == null || MoneyDenominationList.moneylsts.Count == 0)
                moneys = MoneyDenominationList.Instance.GetMoneyList().OrderByDescending(x => x.Denomination).ToList();
            else
                moneys = MoneyDenominationList.moneylsts.OrderByDescending(x => x.Denomination).ToList();

            Dictionary<int, int> bills = calculateBillPay(moneys, mustPaySum);

            PayDTO payDTO = new PayDTO(mustPaySum, bills, horse.Name);
            try
            {
                PayBill(mustPaySum, moneys, bills);
                if(BetList.betlsts != null)
                BetList.betlsts.Remove(bet);
            }
            catch (Exception ex)
            {
                if(ex.Message.Contains("cannot pay"))
                payDTO.isSuccess = false;
            }
            return payDTO;
        }

        private void PayBill(int paysum, List<Money> moneys, Dictionary<int, int> bills)
        {
            try
            {
                //checking
                int amountInBank = 0;
                foreach (var bill in bills)
                    amountInBank = amountInBank + (bill.Key * bill.Value);

                if (amountInBank < paysum)
                    throw new Exception("cannot pay");

                //bill paid
                foreach (Money money in moneys.Where(x => x.Inventory != 0).OrderBy(x => x.Denomination))
                {
                   
                    if (bills.Count > 0)
                    amountOfBills = Convert.ToInt32(bills[money.Denomination]);
                    money.Inventory = money.Inventory - amountOfBills;

                    MoneyDenominationList.Instance.addUpdateMoneyList(moneys, money);
                }
            }
            catch(Exception ex) { throw ex; }
        }
        private Dictionary<int, int> calculateBillPay(List<Money> moneys, int paysum)
        {
            try
            {
                Dictionary<int, int> bills = new Dictionary<int, int>();

                foreach (Money money in moneys)
                {
                    int denominal = money.Denomination;
                    int quantity = money.Inventory;
                    if (quantity == 0)
                        continue;

                    int res = paysum / denominal;

                    if (res <= quantity)
                    {
                        bills.Add(denominal, res);
                        paysum = paysum % denominal;
                    }
                    else
                    {
                        bills.Add(denominal, quantity);
                        paysum = paysum - (denominal * quantity);
                    }
                }
                return bills;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
