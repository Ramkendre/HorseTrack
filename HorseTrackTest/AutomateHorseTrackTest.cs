using System;
using HorseTrackConsoleApp.Data;
using HorseTrackConsoleApp.ModelDTO;
using HorseTrackConsoleApp.Provider;
using HorseTrackConsoleApp.StaticData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HorseTrackTest
{
    [TestClass]
    public class AutomateHorseTrackTest
    {
        [TestMethod]
        public void ReSetStock()
        {
           var chkreset = UserProvider.Instance.ApplyInput(new InputDTO(string.Empty,"r"));

            Assert.AreEqual(chkreset.isError,false);
        }
        [TestMethod]
        public void QuitHorseApp()
        {
            var chkreset = UserProvider.Instance.ApplyInput(new InputDTO(string.Empty, "q"));

            Assert.AreEqual(chkreset.isError, true);
        }

        [TestMethod]
        public void InitialMoneyDenomination()
        {
            var moneyList = MoneyDenominationList.Instance.GetMoneyList();
            Assert.AreEqual(moneyList.Count, 5);
        }
        [TestMethod]
        public void InitialHorses()
        {
            var horseList = HorseList.Instance.getHorseList();
            Assert.AreEqual(horseList.Count, 7);
        }
        [TestMethod]
        public void SetWinHorse()
        {
            var chkreset = HorseProvider.Instance.setNewWinner(new InputDTO("4", "w"));

            Assert.AreEqual(chkreset.isError, false);
        }
        [TestMethod]
        public void PayBet()
        {
            var chkreset = BetProvider.Instance.payByBet(new Bet() { HourseId=1,Betamount=55});

            Assert.AreEqual(chkreset.isSuccess, true);
        }

        [TestMethod]
        public void ValidationTest()
        {
            //check white space
            var checkwhitespace = UserProvider.Instance.ApplyInput(new InputDTO("4", "w "));
            Assert.AreEqual(checkwhitespace.isError, true);
            //Blank Space
            var blankSpace = UserProvider.Instance.ApplyInput(new InputDTO(string.Empty, ""));
            Assert.AreEqual(blankSpace.isError, true);
        }
    }
}
