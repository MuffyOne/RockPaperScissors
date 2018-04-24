namespace RockPaperScissors.Common.Interfaces
{
    public interface IGame
    {
        void ResetGame();
        void SetPlayers(IPlayer playerOne, IPlayer playerTwo);
        IPlayer GetPlayerOne();
        IPlayer GetPlayerTwo();

    }
}
