using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApiMySQLDB.Models
{
    public partial class CcaSite
    {
        public CcaSite()
        {
            CcaUser = new HashSet<CcaUser>();
        }

        public int IdSite { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CcaUser> CcaUser { get; set; }
    }
}
