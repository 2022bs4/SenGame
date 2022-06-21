using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class SystemType
    {
        public SystemType()
        {
            SystemSpecifications = new HashSet<SystemSpecification>();
        }

        public int SystmTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<SystemSpecification> SystemSpecifications { get; set; }
    }
}
