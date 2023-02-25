using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HorseTrackConsoleApp.Utils.HelperUtils;

namespace HorseTrackConsoleApp.ModelDTO
{
   public class InputDTO
    {
        public string Firstparameter;
        public string Secondparameter;

        public string type;

        public bool isError;
        public string errorMsg;

        public InputDTO(string firstinput, string type)
        {
            this.Firstparameter = firstinput;
            this.type = type;
        }
        public InputDTO(string firstinput,string secondinput, string type)
        {
            this.Firstparameter = firstinput;
            this.Secondparameter = secondinput;
            this.type = type;
        }
        public InputDTO(string input, bool isError, string errorMsg)
        {
            this.Firstparameter = input;
            this.isError = isError;
            this.errorMsg = errorMsg;
        }
    }
}
