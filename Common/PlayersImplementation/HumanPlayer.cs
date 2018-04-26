using RockPaperScissors.Common.Enums;
using RockPaperScissors.Common.Interfaces;
using System;

namespace RockPaperScissors.Common.PlayersImplementation
{
    public class HumanPlayer : IPlayer
    {
        public PlayerType PlayerType { get; set; }
        public string PlayerName { get; set; }
        public int Score { get; set; }

       
        public int GetNextMove(IRules ruleSet)
        {
            throw new Exception("UI is responsible to get next move for this type of player");
        }
    }
}
