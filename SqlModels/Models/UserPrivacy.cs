using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SqlModels.Models
{
    public partial class UserPrivacy
    {
        [Display(Name = "隱私ID(UserPrivacyId) : ")]
        public int UserPrivacyId { get; set; }

        [Display(Name = "隱私狀態(PrivacyState) : ")]
        public string PrivacyState { get; set; }
        public string UserId { get; set; }

        public virtual UserModel User { get; set; }
    }
}
