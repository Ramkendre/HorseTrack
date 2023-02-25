using HorseTrackConsoleApp.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackConsoleApp.Interface
{
    public interface IHorseProvider
    {
        InputDTO setNewWinner(InputDTO input);
    }
}
