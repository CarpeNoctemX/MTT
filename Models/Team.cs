using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MTT.Models
{
    public enum Rank
    {
        B, S, G, D, P, C,
    }
 public class Team
    {
        public int TeamID { get; set; }
        public int RoleID { get; set; }
        public int PlayerID { get; set; }
        [DisplayFormat(NullDisplayText = "No rank")]
        public Rank? Rank { get; set; }

        public virtual Role Role { get; set; }
        public virtual Player Player { get; set; }
    }
}