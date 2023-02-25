using HorseTrackConsoleApp.Data;
using HorseTrackConsoleApp.Interface;
using HorseTrackConsoleApp.ModelDTO;
using System;
using static HorseTrackConsoleApp.Utils.HelperMessages;

namespace HorseTrackConsoleApp.Provider
{
   public class UserProvider : singleton<UserProvider>, IUserProvider
    {
        private UserProvider() { }
        public new static UserProvider Instance
        {
            get
            {
                UserProvider.initializer(() =>
                {
                    return new UserProvider();
                });
                return singleton<UserProvider>.Instance;
            }
        }

        /// <summary>
        /// to execute the operation based on input command
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public InputDTO ApplyInput(InputDTO input)
        {
            if (input.isError)
                return input;

            if (RESTOCK.Equals(input.type))
            {
                MoneyProvider.Instance.Restock();
                return input;
            }

            if (HorseWIN.Equals(input.type))
                return HorseProvider.Instance.setNewWinner(input);

            if (HorseBET.Equals(input.type))
            {
                Bet bet = BetProvider.Instance.addBet(Convert.ToInt32(input.Firstparameter), Convert.ToInt32(input.Secondparameter));

                if (bet != null)
                {
                    MoneyProvider.Instance.payBet(bet);
                }
                else
                {
                    input.isError = true;
                    input.errorMsg = InvalidHNumber_msg;
                }

                return input;
            }

            input.isError = true;
            input.errorMsg = Error_msg;
            return input;
        }
    }
}
