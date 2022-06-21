using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class UserEdit
    {
        public UserEdit()
        {
            UserPrivacies = new HashSet<UserPrivacy>();
        }

        public int UserEditId { get; set; }
        public int PersonalFile { get; set; }
        public int? GameFile { get; set; }
        public int FriendsList { get; set; }
        public int ReplyName { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<UserPrivacy> UserPrivacies { get; set; }
    }
}
