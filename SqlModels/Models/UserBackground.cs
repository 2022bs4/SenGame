using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class UserBackground
    {
        public UserBackground()
        {
            UserModel = new HashSet<UserModel>();
        }
        public int UserBackgroundId { get; set; }
        public string BackgroundColor { get; set; }

        public virtual ICollection<UserModel> UserModel { get; set; }

    }
}
