using NUnit.Framework;
using RockPaperScissors.Common.Interfaces;
using RockPaperScissors.Models;

namespace UnitTests
{
    public class GameTests
    {
        [TestCase(3, 1, 1, 2, -1)]
        [TestCase(3, 2, 0, 2, 1)]
        [TestCase(3, 2, 1, 3, 1)]
        [TestCase(3, 1, 2, 3, 2)]
        [TestCase(3, 0, 2, 2, 2)]
        [TestCase(3, 2, 2, 2, -1)]
        [TestCase(3, 3, 3, 3, 0)]
        [TestCase(5, 3, 2, 5, 1)]
        [TestCase(5, 3, 0, 3, 1)]
        [TestCase(5, 4, 4, 4, -1)]
        [TestCase(5, 2, 2, 4, -1)]
        [TestCase(5, 3, 2, 5, 1)]
        [TestCase(5, 2, 3, 5, 2)]
        [TestCase(6, 3, 0, 3, -1)]
        [TestCase(6, 3, 3, 3, -1)]
        [TestCase(6, 3, 3, 6, 0)]  
        [TestCase(6, 4, 0, 4, 1)]
        [TestCase(6, 0, 4, 4, 2)]
        public void Game_GetGameWinner_WinnerIsReturnAccordingly(int numberOfTurns,int playerOneScore, int playerTwoScore,int numberOfPlayedTurns, int expectedWinner)
        {
            //ARRANGE
            IGame game = new Game();
            game.NumerberOfTurns = numberOfTurns;

            //ACT
            var currentWinner = game.GetGameWinner(playerOneScore, playerTwoScore, numberOfPlayedTurns);

            //ASSERT
            Assert.AreEqual(expectedWinner, currentWinner);
        }
    }
}
