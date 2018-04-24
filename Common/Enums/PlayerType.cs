using System.ComponentModel;

namespace RockPaperScissors.Common.Enums
{
    public enum PlayerType
    {
        [Description("Human Player")]
        HumanPlayer = 1,

        [Description("Computer Player")]
        ComputerPlayer = 2,

        [Description("Computer Tactical Player")]
        TacticalPlayer = 3
    }

  
}