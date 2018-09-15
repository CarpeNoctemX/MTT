using System;
using System.ComponentModel.DataAnnotations;

namespace MTT.ViewModels
{
    public class JoinDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? JoinDate { get; set; }

        public int PlayerCount { get; set; }
    }
}