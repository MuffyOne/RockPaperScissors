namespace RockPaperScissors.Common.Interfaces
{
    public interface IGame
    {
       
        IPlayer PlayerOne { get; set; }

        IPlayer PlayerTwo { get; set; }

        IRules Rules { get; set; }

        int NumerberOfTurns { get; set; }

        int GetGameWinner(int playerOneScore, int playerTwoScore, int numberOfPlayedTurns);

    }
}
