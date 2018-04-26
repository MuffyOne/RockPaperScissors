using RockPaperScissors.Common.Interfaces;
using RockPaperScissors.Common.Models;
using System;
using System.Collections.Generic;

namespace RockPaperScissors.Common.Rules
{
    public class RockPaperScissorsRules : IRules
    {
        private static readonly Random _random;
        static RockPaperScissorsRules()
        {
            _random = new Random();
        }

        public List<MoveModel> MoveList
        {
            get
            {
                return new List<MoveModel>
                {
                new MoveModel { Description = "Rock", RuleValue = 1 },
                new MoveModel { Description = "Paper", RuleValue = 2 },
                new MoveModel { Description = "Scissor", RuleValue = 3 }
                };
            }
        }

        public RockPaperScissorsRules()
        {
        }

        public int GetWinningMove(int playerOneMove, int playerTwoMove)
        {
            if (playerOneMove == playerTwoMove)
            {
                return 0;
            }
            else if ((playerOneMove == 1) && (playerTwoMove == 3) ||
              (playerOneMove == 2) && (playerTwoMove == 1) ||
              (playerOneMove == 3) && (playerTwoMove == 2))
            {
                return 1;
            }
            return 2;
        }

        public int GetNextWinningMove(int? lastMove)
        {
            switch (lastMove)
            {
                case 1:
                    return 2;
                case 2:
                    return 3;
                case 3:
                    return 1;
                default:
                    throw new Exception("Unknown last move!");
            }
        }

        public int GetRandomMove()
        {
            var random = _random.Next(MoveList.Count);
            return random + 1;
        }
    }
}
