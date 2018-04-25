using RockPaperScissors.Common.Enums;

namespace RockPaperScissors.Common.Interfaces
{
    public interface IPlayer 
    {
        int GetNextMove(IRules ruleSet);
        PlayerType PlayerType { get; set; }
        string PlayerName { get; set; }
    }
}
