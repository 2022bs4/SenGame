using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class Visa
    {
        public Visa()
        {
            Users = new HashSet<User>();
        }

        public int PayId { get; set; }
        public string VisaCard { get; set; }
        public string VisaDate { get; set; }
        public string VisaSaft { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
