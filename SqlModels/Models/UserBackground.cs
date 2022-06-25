using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class UserBackground
    {
        public UserBackground()
        {
            AspNetUsers = new HashSet<AspNetUser>();
        }

        public int UserBackgroundId { get; set; }
        public string BackgroundColor { get; set; }

        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
