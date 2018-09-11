using System;
using System.Collections.Generic;
namespace MTT.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string LastName { get; set; }
 public string FirstMidName { get; set; }
        public DateTime JoinDate { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}