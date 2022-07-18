using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModels.DTOModels
{
    public class FriendGroupDTO
    {
        //抓群組及好友
        public string GroupName { get; set; }
        public int GroupId { get; set; }
        public string UserName { get; set; }
        public string UserPicture { get; set; }
        public string UserId { get; set; }

        //抓好友及聊天內容
        public string ChatContent { get; set; }
        public DateTime ChatTime { get; set; }
        public string PictureFile { get; set; }

        //刪除群組用
        public int FriendGroupId { get; set; }
        public int UserGroupId { get; set; }
    }
}