using HorseTrackConsoleApp.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackConsoleApp.Interface
{
   public interface IUserProvider
    {
        InputDTO ApplyInput(InputDTO input);
    }
}
