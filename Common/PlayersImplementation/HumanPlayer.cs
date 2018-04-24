using RockPaperScissors.Common.Enums;
using RockPaperScissors.Common.Interfaces;

namespace RockPaperScissors.Common.PlayersImplementation
{
    public class HumanPlayer : IPlayer
    {
        public PlayerType PlayerType { get; set; }
        public string PlayerName { get; set; }
        public int Score { get; set; }

        public RockPaperScissorsMoves GetNextMove()
        {
            return RockPaperScissorsMoves.Paper;
        }
    }
}
