using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class UserCountry
    {
        public UserCountry()
        {
            AspNetUsers = new HashSet<UserModel>();
        }

        public int UserCountryId { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<UserModel> AspNetUsers { get; set; }
    }
}
