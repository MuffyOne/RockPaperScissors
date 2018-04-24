using RockPaperScissors.Common.Interfaces;
using RockPaperScissors.Common.Models;

namespace RockPaperScissors.Models
{
    public class Game : IGame
    {
        #region fields
        //Make this a property and assign it at the beginning of a Match to change the match length
        private int _numerberOfShifts = 3;
        private Player _playerOne;
        private Player _playerTwo;
        private int _shifts;

        public Player GetPlayerOne()
        {
            return _playerOne;
        }

        public Player GetPlayerTwo()
        {
            return _playerTwo;
        }
        #endregion


        public void ResetGame()
        {
            _shifts = 0;
            _playerOne = null;
            _playerTwo = null;
        }

        public void SetPlayers(Player playerOne, Player playerTwo)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
        }


    }
}
