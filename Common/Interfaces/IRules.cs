using RockPaperScissors.Common.Models;
using System.Collections.Generic;

namespace RockPaperScissors.Common.Interfaces
{
    public interface IRules
    {
        int GetWinningMove(int playerOneMove, int playerTwoMove);
        int GetNextWinningMove(int? lastMove);
        int GetRandomMove();
        List<MoveModel> MoveList { get;}
    }
}
