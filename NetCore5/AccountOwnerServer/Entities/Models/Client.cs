using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    //[Table("cca_client", Schema = "cca")]
    [Table("cca_client")]
    public class Client
    {
        public int IdClientBase { get; set; }

        public string Name { get; set; }

        public int? IdClientCIM { get; set; }

        public DateTime? DateLastUpd { get; set; }

        public string IntegrationStatus { get; set; }

        public List<ClientCycle> ClientCycles { get; set; }

    }
}
