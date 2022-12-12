using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPiMySQL.Models
{
    
    public class cca_user
    {
        [Key]
        public int IdUser { get; set; }
        public int IdRol { get; set; }
        public int IdSite { get; set; }
        public string Login { get; set; }
        public int VersionShow { get; set; }
        public string Email { get; set; }
        public int IdCalculationCycleType { get; set; }

        //public virtual CcaRol IdRolNavigation { get; set; }
        //public virtual CcaSite IdSiteNavigation { get; set; }
    }
}



