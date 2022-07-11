using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModels.Models
{
    public class FriendGroup
    {
        public int FriendGroupId { get; set; }
        public string UserId { get; set; }
        public string GroupName { get; set; }

        public virtual UserModel User { get; set; }
    }
}
