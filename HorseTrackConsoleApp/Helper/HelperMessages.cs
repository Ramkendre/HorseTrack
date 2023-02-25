using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackConsoleApp.Utils
{
    public static class HelperMessages
    {
        public static string Inventory_msg =  "Inventory: ";
        public static string Horses_msg = "Horses: ";
        public static string Dispensing_msg = "Dispensing: ";
        public static string Payout_msg = "Payout: ";
        public static string Nopayout_msg = "No Payout: ";
        public static string Dollar_msg = "$";
        public static string Insufficientfunds_msg = "Insufficient Funds: ";
        public static string Won_msg = "Won";
        public static string Lost_msg = "Lost";
        public static string Invalidbet_msg = "Invalid Bet: ";
        public static string Invalidcommand_msg = "Invalid Command: ";
        public static string InvalidHNumber_msg = "Invalid Horse Number: ";
        public static string Error_msg = "unexpected error: ";
        public static string QUIT = "q";
        public static string RESTOCK = "r";
        public static string HorseWIN = "w";
        public static string HorseBET = "b";


        public static bool IsInteger(string value)
        {
            try
            {
                int.Parse(value);
                return true;
            }
            catch { return false; }
        }
    }
}
