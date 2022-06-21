using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class UserBackground
    {
        public UserBackground()
        {
            Users = new HashSet<User>();
        }

        public int UserBackgroundId { get; set; }
        public string BackgroundColor { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
