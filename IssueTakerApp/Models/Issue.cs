using System;
using IssueTakerApp.Models.Enums;

namespace IssueTakerApp.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public virtual User Author { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
