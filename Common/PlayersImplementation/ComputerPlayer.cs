using RockPaperScissors.Common.Enums;
using RockPaperScissors.Common.Interfaces;
using System;

namespace RockPaperScissors.Common.PlayersImplementation
{
    public class ComputerPlayer : IPlayer
    {
        public PlayerType PlayerType { get; set; }
        public string PlayerName { get; set; }
        public int Score { get; set; }

        public int GetNextMove(IRules ruleSet)
        {
            return ruleSet.GetRandomMove();
        }
    }
}
