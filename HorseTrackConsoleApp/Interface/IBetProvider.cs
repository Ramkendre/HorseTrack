using HorseTrackConsoleApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackConsoleApp.Interface
{
   public interface IBetProvider
    {
        Bet addBet(int horseId, int value);
    }
}
