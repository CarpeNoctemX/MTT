using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTT.Models
{
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int RoleID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Champion { get; set; }

        [Range(0, 5)]
        public int KDA { get; set; }

        public int RegionID { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Coach> Coaches { get; set; }
    }
}