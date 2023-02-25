using HorseTrackConsoleApp.Interface;
using HorseTrackConsoleApp.ModelDTO;
using HorseTrackConsoleApp.Provider;
using HorseTrackConsoleApp.StaticData;
using HorseTrackConsoleApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HorseTrackConsoleApp.Utils.HelperMessages;

namespace HorseTrackConsoleApp
{
    class Program
    {
        private static string inputType = string.Empty;
       
        static void Main(string[] args)
        {
             OutputProvider.Instance.ShowBaseInfo();

            InputDTO input = HelperUtils.Instance.getUserInput();
            while (!QUIT.Equals(input.type))
            {
                input = UserProvider.Instance.ApplyInput(input);

                if (!input.isError)
                {
                    if ((HorseList.horselsts == null || HorseList.horselsts.Count == 0) && (MoneyDenominationList.moneylsts == null || MoneyDenominationList.moneylsts.Count == 0))
                        OutputProvider.Instance.ShowBaseInfo();
                    else
                        OutputProvider.Instance.ShowBaseInfo((HorseList.horselsts == null || HorseList.horselsts.Count == 0) ? HorseList.Instance.getHorseList() : HorseList.horselsts,
                            (MoneyDenominationList.moneylsts == null || MoneyDenominationList.moneylsts.Count == 0) ? MoneyDenominationList.Instance.GetMoneyList() : MoneyDenominationList.moneylsts,input.type.ToLower());
                }
                else
                     OutputProvider.Instance.ShowError(input);
               
                input = HelperUtils.Instance.getUserInput();
            }
            //Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
