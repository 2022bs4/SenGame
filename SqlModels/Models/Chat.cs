using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class Chat
    {
        public int ChatId { get; set; }
        public string ChatContent { get; set; }
        public DateTime ChatTime { get; set; }
        public int UserId { get; set; }
        public string PictureFile { get; set; }
    }
}
