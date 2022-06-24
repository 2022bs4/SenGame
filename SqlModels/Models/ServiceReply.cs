using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class ServiceReply
    {
        public int ServiceId { get; set; }
        public string ReplyContent { get; set; }
    }
}
