﻿using System.ComponentModel.DataAnnotations;

namespace IssueTakerApp.Models
{
    public class Sessions
    {
        [Key]
        public string SessionId { get; set; }
        public bool IsActive { get; set; }
        public virtual User User { get; set; }
        public override string ToString()
        {
            return $"{this.SessionId}\t{this.User.Id}";
        }
    }
}
