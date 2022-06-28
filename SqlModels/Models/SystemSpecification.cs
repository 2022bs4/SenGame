using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class SystemSpecification
    {
        public int SystemSpecificationId { get; set; }
        public int SystemType { get; set; }
        public int? Configure { get; set; }
        public string Hddspace { get; set; }
        public string System { get; set; }
        public string SystemRam { get; set; }
        public string SystemCpu { get; set; }
        public string SystemGpu { get; set; }
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}
