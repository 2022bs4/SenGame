using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class UserCountry
    {
        public UserCountry()
        {
            Users = new HashSet<User>();
        }

        public int UserCountryId { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
