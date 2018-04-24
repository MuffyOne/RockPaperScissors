using System;

namespace RockPaperScissors.Common.Models
{
    public class PlayerTypeBinder
    {
        public bool IsChecked { get; set; }

        public Enums.PlayerType PlayerType { get; set; }

        public string Description { get; set; }

        public Guid Group { get; set; }
    }
}
 