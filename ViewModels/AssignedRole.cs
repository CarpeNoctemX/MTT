using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MTT.ViewModels
{
    public class AssignedRole
    {
        public int RoleID { get; set; }
        public string Champion { get; set; }
        public bool Assigned { get; set; }
    }
}