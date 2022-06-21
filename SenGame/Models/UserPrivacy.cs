using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class UserPrivacy
    {
        public int UserPrivacyId { get; set; }
        public int UserEditId { get; set; }
        public string PrivacyState { get; set; }

        public virtual UserEdit UserEdit { get; set; }
    }
}
