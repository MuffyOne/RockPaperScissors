using RockPaperScissors.Common.Interfaces;
using RockPaperScissors.Common.Models;

namespace RockPaperScissors.Models
{
    public class Game : IGame
    {
        //Make this a property and assign it at the beginning of a Match to change the match length
        private int NumerberOfShifts = 3;

        private Player _playerOne;

        public Player _playerTwo;

        public void ResetGame()
        {
            
        }

        public void SetPlayers(Player playerOne, Player playerTwo)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
        }
    }
}
