using RockPaperScissors.Common.Enums;

namespace RockPaperScissors.Common.Models
{
    public interface IBasePlayer
    {
        PlayerType PlayerType { get; set; }
        string PlayerName { get; set; }
        int Score { get; set; }
    }
}
