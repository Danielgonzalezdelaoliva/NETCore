using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApiMySQLDB.Models
{
    public partial class CcaUser
    {
        public int IdUser { get; set; }
        
        public int IdRol { get; set; }
        
        public int IdSite { get; set; }

        [Required (ErrorMessage ="Login es obligatorio")]
        [MaxLength (ErrorMessage ="El valor de login tiene que ser máximo de 100 carácteres")]
        public string Login { get; set; }
        
        public int VersionShow { get; set; }
        
        public string Email { get; set; }
        
        public int IdCalculationCycleType { get; set; }

        public virtual CcaRol IdRolNavigation { get; set; }
        public virtual CcaSite IdSiteNavigation { get; set; }
    }
}
    