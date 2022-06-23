using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class UserPrivacy
    {
        public int UserPrivacyId { get; set; }
        public string PrivacyState { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
