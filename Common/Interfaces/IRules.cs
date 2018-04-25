namespace RockPaperScissors.Common.Interfaces
{
    public interface IRules
    {
        int GetWinningMove(int playerOneMove, int playerTwoMove);
        int GetNextWinningMove(int? lastMove);
        int GetRandomMove();
       
    }
}
