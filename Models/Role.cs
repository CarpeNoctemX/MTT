using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace MTT.Models
{
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoleID { get; set; }
        public string Champion { get; set; }
        public int KDA { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}