using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class UserPrivacy
    {
        public int UserPrivacyId { get; set; }
        public string PrivacyState { get; set; }
        public string UserId { get; set; }

        public virtual UserModel User { get; set; }
    }
}
