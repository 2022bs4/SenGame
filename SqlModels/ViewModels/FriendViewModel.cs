using SqlModels.Models;
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
            public string GroupName { get; set; }
            public string Name { get; set; }
            public string Photo { get; set; }
            public string Id { get; set; }
        }
        //把資料變成一對一(C)
        public string[] Ids { get; set; }
        public string[] GroupNames { get; set; }

    }


    



}
