using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Common.Interfaces
{
    public interface IGameRules
    {
        int GetWinningMove(int playerOneMove, int playerTwoMove);

    }
}
