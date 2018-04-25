namespace RockPaperScissors.Common.Interfaces
{
    public interface IGame
    {
        void ResetGame();
        
        IPlayer PlayerOne { get; set; }

        IPlayer PlayerTwo { get; set; }

        IRules Rules { get; set; }

    }
}
