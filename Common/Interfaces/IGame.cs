using RockPaperScissors.Common.Models;

namespace RockPaperScissors.Common.Interfaces
{
    public interface IGame
    {
        void ResetGame();

        void SetPlayers(Player playerOne, Player playerTwo);

        Player GetPlayerOne();

        Player GetPlayerTwo();

    }
}
