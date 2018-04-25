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
        #endregion

        public int GetNextMove(IRules rulesSet)
        {
            int move = -1;
            if (_lastMove == null)
            {
                 move = rulesSet.GetRandomMove();
                
            }
            else
            {
               move = rulesSet.GetNextWinningMove(_lastMove);
            }
            _lastMove = move;
            return move;
        }
    }
}
