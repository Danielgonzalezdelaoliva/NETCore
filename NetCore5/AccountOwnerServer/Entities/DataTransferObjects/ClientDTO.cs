using System;
using System.Collections.Generic;

namespace Entities.DataTransferObjects
{
    public class ClientDTO
    {
        public int IdClientBase { get; set; }

        public string Name { get; set; }

        public int? IdClientCIM { get; set; }

        public DateTime? DateLastUpd { get; set; }

        public string IntegrationStatus { get; set; }

        public string Integration { get; set; }

        public IEnumerable<ClientCycleDTO> ClientCycles { get; set; }
    }
}
