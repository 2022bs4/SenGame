using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModels.Models
{
    public class TypeGroup
    {
        public TypeGroup()
        {
            Typelist = new HashSet<Typelist>();
        }

        public int GroupId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Typelist> Typelist { get; set; }
    }
}
