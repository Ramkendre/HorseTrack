using HorseTrackConsoleApp.Data;
using HorseTrackConsoleApp.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackConsoleApp.Interface
{
    public interface IOutputProvider
    {
        void ShowBaseInfo();

        void ShowError(InputDTO input);

        void ShowPaySuccess(PayDTO payDTO);

        void ShowPayFail(PayDTO payDTO);

        void ShowNoPayout(Horse horse);
    }
}
