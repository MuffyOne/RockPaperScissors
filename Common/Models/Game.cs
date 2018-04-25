using RockPaperScissors.Common.Interfaces;

namespace RockPaperScissors.Models
{
    public class Game : IGame
    { 
        #region properties
        public int NumerberOfTurns { get; set; }
        public IPlayer PlayerOne { get; set; }
        public IPlayer PlayerTwo { get; set; }
        public IRules Rules { get; set; }

        public int GetGameWinner(int playerOneScore, int playerTwoScore)
        {
            if(playerOneScore == playerTwoScore && playerOneScore<NumerberOfTurns)
            {
                return -1;
            }
            if(playerOneScore > NumerberOfTurns/2.0)
            {
                return 1;
            }
            else if(playerTwoScore > NumerberOfTurns/2.0)
            {
                return 2;
            }
            else if(playerTwoScore+playerOneScore==NumerberOfTurns)
            {
                return 0;
            }
            return -1;
        }
        #endregion

        public void ResetGame()
        {
           
        }
    }

}
