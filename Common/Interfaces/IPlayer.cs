using RockPaperScissors.Common.Enums;
using RockPaperScissors.Common.Models;

namespace RockPaperScissors.Common.Interfaces
{
    public interface IPlayer : IBasePlayer
    {
        RockPaperScissorsMoves GetNextMove();
    }
}
