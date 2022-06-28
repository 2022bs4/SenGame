using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class UserCountry
    {
        public UserCountry()
        {
            AspNetUsers = new HashSet<AspNetUser>();
        }

        public int UserCountryId { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
