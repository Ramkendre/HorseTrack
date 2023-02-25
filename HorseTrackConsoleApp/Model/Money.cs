using HorseTrackConsoleApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackConsoleApp.Data
{
   public class Money
    {
        public int Mid { get; set; }
        public int Denomination { get; set; }
        public int Inventory { get; set; }
        public Money()
        {

        }
        public Money(int mid,int denomination,int inventory)
        {
            Mid = mid;
            Denomination = denomination;
            Inventory = inventory;
        }
        public string toString()
        {
            return HelperMessages.Dollar_msg + Denomination + "," + Inventory;
        }
    }
}
