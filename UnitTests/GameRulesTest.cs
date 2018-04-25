using NUnit.Framework;
using RockPaperScissors.Common.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class GameRulesTest
    {
        [TestCase(1,1,0)]
        [TestCase(2, 2, 0)]
        [TestCase(3, 3, 0)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 3, 1)]
        [TestCase(2, 1, 1)]
        [TestCase(2, 3, 2)]
        [TestCase(3, 1, 2)]
        [TestCase(3, 2, 1)]
        public void RockPaperScissorsRules_GetWinningMove_WinnerCorrect(int playerOneMove,int playerTwoMove, int expectedResult)
        {
            //ARRANGE
            RockPaperScissorsRules ruleSet = new RockPaperScissorsRules();

            //ACT
            var winningPlayer = ruleSet.GetWinningMove(playerOneMove, playerTwoMove);

            //ASSERT
            Assert.AreEqual(expectedResult, winningPlayer);
        }
    }
}
