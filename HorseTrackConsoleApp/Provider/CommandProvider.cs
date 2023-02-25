using HorseTrackConsoleApp.Interface;
using System;
using static HorseTrackConsoleApp.Utils.HelperMessages;

namespace HorseTrackConsoleApp.Provider
{ 
    /// <summary>
    /// To verify the input commands
    /// </summary>
    public class CommandProvider : ICommandProvider
    {
        string UserInput = string.Empty;
         string[] split;
        public CommandProvider(string userInput)
        {
            UserInput = userInput.ToLower();
            split = UserInput.Split(' ');
        }
        /// <summary>
        /// reset the stock
        /// </summary>
        /// <returns></returns>
        public bool isRestock()
        {
            return RESTOCK.Equals(split[0]);
        }
       
        public bool isSetWinHorse()
        {
            if (split.Length == 2 && HorseWIN.Equals(split[0]) && IsInteger(split[1]))
                return true;

            return false;
        }
        public bool isSetBetHorse()
        {
            // string[] split = userInput.Split(' ');
            if (split.Length == 2 && IsInteger(split[0]) && IsInteger(split[1]))
                return true;
           
            return false;
        }
        public bool isQuit()
        {
            return QUIT.Equals(split[0]);
        }
    }
}
