using HorseTrackConsoleApp.Data;
using HorseTrackConsoleApp.Interface;
using System.Collections.Generic;
using System.Linq;

namespace HorseTrackConsoleApp.StaticData
{
    public class HorseList : singleton<HorseList>
    {
        private HorseList() { }
        public new static HorseList Instance
        {
            get
            {
                HorseList.initializer(() =>
                {
                    return new HorseList();
                });
                return singleton<HorseList>.Instance;
            }
        }

        public List<Horse> horselst =new List<Horse>();
        public static List<Horse> horselsts;
        /// <summary>
        /// get the initial horse status
        /// </summary>
        public List<Horse> getHorseList()
        {
            horselst.Clear();
            horselst.Add(new Horse() { Hid = 1, Name = "That Darn Gray Cat", Odds = 5, IsWin = true });
            horselst.Add(new Horse() { Hid = 2, Name = "Fort Utopia", Odds = 10, IsWin = false });
            horselst.Add(new Horse() { Hid = 3, Name = "Count Sheep", Odds = 9, IsWin = false });
            horselst.Add(new Horse() { Hid = 4, Name = "Ms Traitour", Odds = 4, IsWin = false });
            horselst.Add(new Horse() { Hid = 5, Name = "Real Princess", Odds = 3, IsWin = false });
            horselst.Add(new Horse() { Hid = 6, Name = "Pa Kettle", Odds = 5, IsWin = false });
            horselst.Add(new Horse() { Hid = 7, Name = "Gin Stinger", Odds = 6, IsWin = false });
            return horselst;
        }
        /// <summary>
        /// update the horse win status
        /// </summary>
        ///  <param name="horse">update the horse status</param>

        public void addUpdateHorseList(List<Horse> horses, Horse horse)
        {
            try
            {
                horses.Where(x => x.Hid == horse.Hid).FirstOrDefault().IsWin = horse.IsWin;
                horselsts = horses;
            }
            catch { }
        }
    }
}
