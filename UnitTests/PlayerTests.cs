using NUnit.Framework;
using RockPaperScissors.Common.Interfaces;
using RockPaperScissors.Common.PlayersImplementation;
using RockPaperScissors.Common.Rules;

namespace UnitTests
{
    public class PlayerTests
    {
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 1)]
        public void TacticalPlayer_GetNextMove_NextMoveIsCorrect(int lastMove, int expectedMove)
        {
            //ARRANGE
            IRules rules = new RockPaperScissorsRules();
            IPlayer player = new TacticalPlayer(lastMove);

            //ACT
            int nextMove = player.GetNextMove(rules);

            //ASSERT
            Assert.AreEqual(expectedMove, nextMove);
        }

        [Test]
        [Repeat(10)]
        public void ComputerPlayer_GetNextMove_NextMoveIsInsidePossibleMoves()
        {
            //ARRANGE
            IRules rules = new RockPaperScissorsRules();
            IPlayer player = new ComputerPlayer();

            //ACT
            int nextMove = player.GetNextMove(rules);

            //ASSERT
            Assert.That(nextMove, Is.InRange(1, 3));
        }
    }
}
