using RockPaperScissors.Common.Enums;
using RockPaperScissors.Common.Interfaces;
using RockPaperScissors.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Common.PlayersImplementation
{
    public class TacticalPlayer : IPlayer
    {
        private RockPaperScissorsMoves? _lastMove;

        #region constructor
        public TacticalPlayer()
        {

        }

        public TacticalPlayer(RockPaperScissorsMoves lastMoveByPass)
        {
            _lastMove = lastMoveByPass;
        }

        public PlayerType PlayerType { get; set; }
        public string PlayerName { get; set ; }
        public int Score { get; set; }
        #endregion

        public RockPaperScissorsMoves GetNextMove()
        {
           if(_lastMove == null)
            {
                var move = GetRandomMove();
                _lastMove = move;
                return move;
            }
           else
            {
                switch(_lastMove)
                {
                    case RockPaperScissorsMoves.Rock:
                        return RockPaperScissorsMoves.Paper;
                    case RockPaperScissorsMoves.Paper:
                        return RockPaperScissorsMoves.Scissors;
                    case RockPaperScissorsMoves.Scissors:
                        return RockPaperScissorsMoves.Rock;
                    default:
                        throw new Exception("Unknown last move!");
                }
            }

        }

        private RockPaperScissorsMoves GetRandomMove()
        {
            var values = Enum.GetValues(typeof(RockPaperScissorsMoves));
            Random random = new Random();
            RockPaperScissorsMoves randomMove = (RockPaperScissorsMoves)values.GetValue(random.Next(values.Length));
            return randomMove;
        }
    }
}
