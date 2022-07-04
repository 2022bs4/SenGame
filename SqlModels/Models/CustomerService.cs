using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class CustomerService
    {
        public int ServiceId { get; set; }
        public int GameId { get; set; }
        public string QuestionContent { get; set; }
        public DateTime CreateTime { get; set; }
        public string UserId { get; set; }

        public virtual Game Game { get; set; }
        public virtual UserModel User { get; set; }
    }
}
