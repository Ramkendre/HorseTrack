using HorseTrackConsoleApp.Interface;
using HorseTrackConsoleApp.ModelDTO;
using HorseTrackConsoleApp.Provider;
using System;
using static HorseTrackConsoleApp.Utils.HelperMessages;

namespace HorseTrackConsoleApp.Utils
{
    public class HelperUtils : singleton<HelperUtils>
    {
        private HelperUtils() { }
        public new static HelperUtils Instance
        {
            get
            {
                HelperUtils.initializer(() =>
                {
                    return new HelperUtils();
                });
                return singleton<HelperUtils>.Instance;
            }
        }

        private  ICommandProvider IcommandProvider;
        private string UserInput = string.Empty;
        /// <summary>
        /// Enter the user input command
        /// </summary>
        /// <returns></returns>
        public InputDTO getUserInput()
        {
            try
            {
                UserInput = Console.ReadLine();
                IcommandProvider = new CommandProvider(UserInput);
                if (!string.IsNullOrWhiteSpace(UserInput.ToLower()) && !string.IsNullOrEmpty(UserInput.ToLower()))
                {
                    if (IcommandProvider.isQuit())
                        return new InputDTO(UserInput, QUIT);

                    if (IcommandProvider.isRestock())
                        return new InputDTO(UserInput, RESTOCK);

                    if (IcommandProvider.isSetWinHorse())
                        return new InputDTO(UserInput.Split(' ')[1], HorseWIN);

                    if (IcommandProvider.isSetBetHorse())
                    {
                        string[] split = UserInput.Split(' ');
                        string horseId = split[0];
                        string betSum = split[1];

                        if (IsInteger(horseId) && IsInteger(betSum))
                            return new InputDTO(horseId, betSum, HorseBET);
                        else
                            return new InputDTO(betSum, true, Invalidbet_msg);
                    }

                    return new InputDTO(UserInput, true, Invalidcommand_msg);
                }
                else
                    return new InputDTO(UserInput, true, Invalidcommand_msg);
            }
            catch(Exception ex) { return new InputDTO(UserInput, true, ex.Message); }
        }
    }
}
