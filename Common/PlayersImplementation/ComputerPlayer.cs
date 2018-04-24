using RockPaperScissors.Common.Enums;
using RockPaperScissors.Common.Interfaces;
using RockPaperScissors.Common.Models;
using System;

namespace RockPaperScissors.Common.PlayersImplementation
{
    public class ComputerPlayer :  IPlayer
    {
        public PlayerType PlayerType { get; set; }
        public string PlayerName { get; set; }
        public int Score { get; set; }

        public RockPaperScissorsMoves GetNextMove()
        {
            var values = Enum.GetValues(typeof(RockPaperScissorsMoves));
            Random random = new Random();
            RockPaperScissorsMoves randomMove = (RockPaperScissorsMoves)values.GetValue(random.Next(values.Length));
            return randomMove; 
        }
    }
}
