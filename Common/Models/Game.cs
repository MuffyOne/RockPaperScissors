using RockPaperScissors.Common.Interfaces;
using RockPaperScissors.Common.Models;

namespace RockPaperScissors.Models
{
    public class Game : IGame
    {
        #region fields
        //Make this a property and assign it at the beginning of a Match to change the match length
        public const int _numerberOfShifts = 3;
        private IPlayer _playerOne;
        private IPlayer _playerTwo;
        private int _shifts;

        public IPlayer GetPlayerOne()
        {
            return _playerOne;
        }

        public IPlayer GetPlayerTwo()
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

        public void SetPlayers(IPlayer playerOne, IPlayer playerTwo)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
        }


    }
}
