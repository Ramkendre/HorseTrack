using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackConsoleApp.ModelDTO
{
    public class PayDTO
    {
        public bool isSuccess;

        public string horseName;
        public int totalSum;

        public Dictionary<int, int> bills;

        public PayDTO(int totalSum, Dictionary<int, int> bills, string horseName)
        {
            this.totalSum = totalSum;
            this.bills = bills;
            this.horseName = horseName;

            this.isSuccess = true;
        }
    }
}
