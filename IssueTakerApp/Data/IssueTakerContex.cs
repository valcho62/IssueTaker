using IssueTakerApp.Models;

namespace IssueTakerApp.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class IssueTakerContex : DbContext
    {
       
        public IssueTakerContex()
            : base("name=IssueTakerContex")
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<Sessions> Sessions{ get; set; }
    }

    
}