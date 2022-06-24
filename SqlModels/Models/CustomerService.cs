using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class CustomerService
    {
        public int MyGameId { get; set; }
        public string QuestionContent { get; set; }
        public DateTime CreateTime { get; set; }
        public int ServiceId { get; set; }

        public virtual MyGame MyGame { get; set; }
    }
}
