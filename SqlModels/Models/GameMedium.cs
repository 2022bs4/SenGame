using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class GameMedium
    {
        public int GameMediaId { get; set; }
        public int GameId { get; set; }
        public string MediaUrl { get; set; }
        public int InstructionType { get; set; }
        public int Instruction { get; set; }
        public int Sort { get; set; }

        public virtual Game Game { get; set; }
    }
}
