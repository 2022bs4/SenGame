using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModels.ViewModels
{
    public class FriendViewModel
    {

        public List<Group> Groups { get; set; }
        public class Group
        {
            public string GroupName { get; set; }
            public List<Friend> Friends { get; set; }
        }

        public class Friend
        {
            public string Name { get; set; }
            public string Photo { get; set; }
        }

    }


    



}
