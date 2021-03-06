using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class Chat
    {
        public string ChatContent { get; set; }
        public DateTime ChatTime { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public string PictureFile { get; set; }

        public virtual User User { get; set; }
    }
}
