using RockPaperScissors.Common.Interfaces;
using RockPaperScissors.Common.Models;
using System;
using System.Collections.Generic;

namespace RockPaperScissors.Common.Rules
{
    public class RockPaperScissorsRules : IRules
    {
        private Random _random;
        public List<RuleModel> rulesList;

        public RockPaperScissorsRules()
        {

            _random = new Random();
            rulesList = new List<RuleModel>
            {
                new RuleModel { Description = "Rock", RuleValue = 1 },
                new RuleModel { Description = "Paper", RuleValue = 2 },
                new RuleModel { Description = "Scissor", RuleValue = 3 }
            };
        }

        public int GetWinningMove(int playerOneMove, int playerTwoMove)
        {
            if (playerOneMove == playerTwoMove)
            {
                return 0;
            }
            else if ((playerOneMove == 1) && (playerTwoMove == 3) ||
              (playerOneMove == 2) && (playerTwoMove ==1) ||
              (playerOneMove == 3) && (playerTwoMove == 2))
            {
                return 1;
            }
            return -1;
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
            
            return _random.Next(rulesList.Count);
        }
    }
}
