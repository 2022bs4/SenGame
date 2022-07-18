using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SqlModels.Models
{
    public partial class MyGame
    {
        [Key]
        public int MyGameId { get; set; }
        public string Id { get; set; }
        public int GameId { get; set; }
        public bool MyFavourite { get; set; }

        public virtual Game Game { get; set; }
        public virtual UserModel User { get; set; }
    }
}
