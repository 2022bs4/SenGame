using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Account { get; set; }
        public string Email { get; set; }
        public bool EmailConfirm { get; set; }
        public DateTime? EmailConfirmDate { get; set; }
        public string PassWord { get; set; }
        public string Address { get; set; }
        public string UserPicture { get; set; }
        public string UsernickName { get; set; }
        public int? UserCountryId { get; set; }
        public DateTime? CreateTime { get; set; }
        public string UserAbout { get; set; }
        public int UserBackgroundId { get; set; }
        public int? OrderId { get; set; }
        public int PrivacyPersonalFile { get; set; }
        public int PrivacyGameFile { get; set; }
        public int PrivacyFriendsList { get; set; }
    }
}
