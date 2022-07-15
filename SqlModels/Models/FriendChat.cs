using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModels.Models
{
    public class FriendChat
    {
        public int FriendChatId { get; set; }
        public int ChatId { get; set; }
        public string UserId { get; set; }
        public string ChatContent { get; set; }
        public DateTime ChatTime { get; set; }
        public string PictureFile { get; set; }
        public virtual UserModel User { get; set; }
    }
}
