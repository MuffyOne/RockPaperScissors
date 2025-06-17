namespace RockPaperScissors.Common.Interfaces
{
    public interface IGame
    {
       
        IPlayer PlayerOne { get; set; }

        IPlayer PlayerTwo { get; set; }

        IRules Rules { get; set; }

        int NumberOfTurns { get; set; }

        int GetGameWinner(int playerOneScore, int playerTwoScore, int numberOfPlayedTurns);

    }
}
