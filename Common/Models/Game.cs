using RockPaperScissors.Common.Interfaces;

namespace RockPaperScissors.Models
{
    public class Game : IGame
    {
        #region fields
        //Make this a property and assign it at the beginning of a Match to change the match length
        public const int _numerberOfTurns = 3;
        private IPlayer _playerOne;
        private IPlayer _playerTwo;
        private IRules _rules;
        private int _shifts;
        #endregion

        #region properties
        public IPlayer PlayerOne { get; set; }
        public IPlayer PlayerTwo { get; set; }
        public IRules Rules { get; set; }
        #endregion

        public void ResetGame()
        {
            _shifts = 0;
            _playerOne = null;
            _playerTwo = null;
        }
    }

}
