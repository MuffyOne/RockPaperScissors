using NUnit.Framework;
using RockPaperScissors.Common.Enums;
using RockPaperScissors.Common.Interfaces;
using RockPaperScissors.Common.PlayersImplementation;

namespace UnitTests
{
    public class PlayerTests
    {
        [TestCase(RockPaperScissorsMoves.Rock, RockPaperScissorsMoves.Paper)]
        [TestCase(RockPaperScissorsMoves.Paper, RockPaperScissorsMoves.Scissors)]
        [TestCase(RockPaperScissorsMoves.Scissors, RockPaperScissorsMoves.Rock)]
        public void TacticalPlayer_GetNextMove_NextMoveIsCorrect(RockPaperScissorsMoves lastMove, RockPaperScissorsMoves expectedMove)
        {
            //ARRANGE
            IPlayer player = new TacticalPlayer(lastMove);

            //ACT
            RockPaperScissorsMoves nextMove = player.GetNextMove();

            //ASSERT
            Assert.AreEqual(expectedMove, nextMove);
        }
    }
}
