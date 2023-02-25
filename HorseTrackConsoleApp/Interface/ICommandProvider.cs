using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackConsoleApp.Interface
{
    public interface ICommandProvider
    {
        bool isRestock();
        bool isSetWinHorse();
        bool isSetBetHorse();
        bool isQuit();
    }
}
