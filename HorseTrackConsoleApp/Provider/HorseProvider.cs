using HorseTrackConsoleApp.Data;
using HorseTrackConsoleApp.Interface;
using HorseTrackConsoleApp.ModelDTO;
using HorseTrackConsoleApp.StaticData;
using System;
using System.Linq;
using static HorseTrackConsoleApp.Utils.HelperMessages;

namespace HorseTrackConsoleApp.Provider
{
    public class HorseProvider : singleton<HorseProvider>,IHorseProvider
    {
        private HorseProvider() { }
        public new static HorseProvider Instance
        {
            get
            {
                HorseProvider.initializer(() =>
                {
                    return new HorseProvider();
                });
                return singleton<HorseProvider>.Instance;
            }
        }
        public InputDTO setNewWinner(InputDTO input)
        {
            try
            {
                Horse horse = setWinHorse(Convert.ToInt32(input.Firstparameter));
                MoneyProvider.Instance.payHorse(horse);
            }
            catch (Exception ex)
            {
                input.isError = true;
                input.errorMsg = ex.Message;
            }
            return input;
        }

        private Horse setWinHorse(int hId)
        {
            Horse horse = null;
            Horse preWinhorse = null;
            try
            {
                if (HorseList.horselsts == null || HorseList.horselsts.Count == 0)
                    horse = HorseList.Instance.getHorseList().Where(x => x.Hid == hId).FirstOrDefault();
                else
                    horse = HorseList.horselsts.Where(x => x.Hid == hId).FirstOrDefault();

                if (horse == null)
                    throw new NullReferenceException(InvalidHNumber_msg);

                if (HorseList.horselsts == null || HorseList.horselsts.Count == 0)
                    preWinhorse = HorseList.Instance.getHorseList().Where(x => x.IsWin == true).FirstOrDefault();
                else
                     preWinhorse = HorseList.horselsts.Where(x => x.IsWin == true).FirstOrDefault();
                if (preWinhorse != null)
                {
                    preWinhorse.IsWin = false;
                    if (HorseList.horselsts == null || HorseList.horselsts.Count == 0)
                        HorseList.Instance.addUpdateHorseList(HorseList.Instance.getHorseList().ToList(), preWinhorse);
                    else
                        HorseList.Instance.addUpdateHorseList(HorseList.horselsts, preWinhorse);
                }

                horse.IsWin = true;
                if (HorseList.horselsts == null || HorseList.horselsts.Count == 0)
                    HorseList.Instance.addUpdateHorseList(HorseList.Instance.getHorseList().ToList(), horse);
                else
                    HorseList.Instance.addUpdateHorseList(HorseList.horselsts, horse);
            }
            catch(Exception ex)
            {
               
            }
            return horse;
        }
    }
}
