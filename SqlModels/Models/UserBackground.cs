using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SqlModels.Models
{
    public partial class UserBackground
    {
        public UserBackground()
        {
            UserModel = new HashSet<UserModel>();
        }
        [Display(Name = "使用者背景ID(UserBackgroundId) : ")]
        public int UserBackgroundId { get; set; }

        [Display(Name = "使用者背景顏色(BackgroundColor) : ")]
        public string BackgroundColor { get; set; }

        public virtual ICollection<UserModel> UserModel { get; set; }

    }
}
