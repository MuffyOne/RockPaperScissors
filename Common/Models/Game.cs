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


        /*Checking against the number of played turns allows more flexibility, the logic works fine in both this scenarios:
         - don't assign any point in case of draw
         - both player gets one point in case of draw.
        In the second case a best six game with a score of 3-3 can mean two different things:
            - both players won a turn each and 6 turns where played. game is drawn
            - only 3 rounds played and all 3 where ties. game needs to continue on.
        */
        public int GetGameWinner(int playerOneScore, int playerTwoScore, int numberOfPlayedTurns)
        {
            if (numberOfPlayedTurns == NumerberOfTurns)
            {
                if (playerTwoScore == playerOneScore)
                {
                    return 0;
                }
                else if (playerOneScore < playerTwoScore)
                {
                    return 2;
                }
                return 1;
            }
            else if(playerOneScore == playerTwoScore && numberOfPlayedTurns< NumerberOfTurns)
            {
                return -1;
            }
            else
            {
                if (playerOneScore > NumerberOfTurns / 2.0)
                {
                    return 1;
                }
                else if (playerTwoScore > NumerberOfTurns / 2.0)
                {
                    return 2;
                }
            }
            return -1;
        }
        #endregion

    }

}
