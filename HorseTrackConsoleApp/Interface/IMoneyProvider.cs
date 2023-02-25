using HorseTrackConsoleApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackConsoleApp.Interface
{
   public interface IMoneyProvider
    {
        void Restock();
        void payHorse(Horse horse);
        void payBet(Bet bet);
    }
}
