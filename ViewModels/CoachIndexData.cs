using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MTT.Models;

namespace MTT.ViewModels
{
    public class CoachIndexData
    {
        public IEnumerable<Coach> Coaches { get; set; }
        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<Team> Teams { get; set; }
    }
}