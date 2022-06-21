using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class SystemSpecification
    {
        public int SystemId { get; set; }
        public int SystemTypeId { get; set; }
        public string Hddspace { get; set; }
        public string System { get; set; }
        public string SystemRam { get; set; }
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
        public virtual SystemType SystemType { get; set; }
    }
}
