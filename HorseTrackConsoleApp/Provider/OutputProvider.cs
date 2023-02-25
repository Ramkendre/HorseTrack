using HorseTrackConsoleApp.Data;
using HorseTrackConsoleApp.Interface;
using HorseTrackConsoleApp.ModelDTO;
using HorseTrackConsoleApp.StaticData;
using HorseTrackConsoleApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HorseTrackConsoleApp.Provider
{
    public class OutputProvider : singleton<OutputProvider>, IOutputProvider
    {
        private OutputProvider() { }
        public new static OutputProvider Instance
        {
            get
            {
                OutputProvider.initializer(() =>
                {
                    return new OutputProvider();
                });
                return singleton<OutputProvider>.Instance;
            }
        }

        /// <summary>
        /// to get the initial inventory and horse lists.
        /// </summary>
        public void ShowBaseInfo()
        {
            if (HorseList.horselsts != null)
                HorseList.horselsts.Clear();
            if (MoneyDenominationList.moneylsts != null)
                MoneyDenominationList.moneylsts.Clear();

            Console.WriteLine(HelperMessages.Inventory_msg);
            var moneys = MoneyDenominationList.Instance.GetMoneyList();
            foreach (Money money in moneys)
                Console.WriteLine(money.toString());
            Console.WriteLine(HelperMessages.Horses_msg);
            var horses = HorseList.Instance.getHorseList();
            foreach (Horse horse in horses)
                Console.WriteLine(horse.toString());
        }

        public void ShowBaseInfo(List<Horse> horses, List<Money> moneys,string type)
        {
            if (type != "r")
            {
                Console.WriteLine(HelperMessages.Inventory_msg);
                foreach (Money money in moneys)
                    Console.WriteLine(money.toString());
                Console.WriteLine(HelperMessages.Horses_msg);
                foreach (Horse horse in horses)
                    Console.WriteLine(horse.toString());
            }
            else
                ShowBaseInfo();
        }
        /// <summary>
        /// to show the runtime error message
        /// </summary>
        public void ShowError(InputDTO input)
        {
            Console.WriteLine(input.errorMsg + input.Firstparameter);
        }
        /// <summary>
        /// to show the no payout message
        /// </summary>
        /// <param name="horse"></param>
        public void ShowNoPayout(Horse horse)
        {
            Console.WriteLine(HelperMessages.Nopayout_msg + horse.Name);
        }
        /// <summary>
        /// to show the payment is successfully submitted
        /// </summary>
        /// <param name="payDTO"></param>
        public void ShowPaySuccess(PayDTO payDTO)
        {
            Console.WriteLine(HelperMessages.Payout_msg + payDTO.horseName + "," + HelperMessages.Dollar_msg + payDTO.totalSum);
            Console.WriteLine(HelperMessages.Dispensing_msg);

            foreach (var bill in payDTO.bills.OrderBy(x => x.Key))
                Console.WriteLine(HelperMessages.Dollar_msg + bill.Key + ": " + bill.Value);
        }
        /// <summary>
        /// to show the error message of insufficient fund.
        /// </summary>
        /// <param name="payDTO"></param>
        public void ShowPayFail(PayDTO payDTO)
        {
            Console.WriteLine(HelperMessages.Insufficientfunds_msg + HelperMessages.Dollar_msg + payDTO.totalSum);
        }
    }
}
