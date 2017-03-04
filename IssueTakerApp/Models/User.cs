﻿using IssueTakerApp.Models.Enums;

namespace IssueTakerApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

    }
}
