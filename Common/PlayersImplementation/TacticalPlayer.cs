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
        private int? _lastMove;

        #region constructor
        public TacticalPlayer()
        {

        }

        public TacticalPlayer(int lastMoveByPass)
        {
            _lastMove = lastMoveByPass;
        }

        public PlayerType PlayerType { get; set; }
        public string PlayerName { get; set; }
        public int Score { get; set; }
        #endregion

        public int GetNextMove(IRules rulesSet)
        {
            if (_lastMove == null)
            {
                var move = rulesSet.GetRandomMove();
                _lastMove = move;
                return move;
            }
            else
            {
                return rulesSet.GetNextWinningMove(_lastMove);
            }

        }
    }
}
