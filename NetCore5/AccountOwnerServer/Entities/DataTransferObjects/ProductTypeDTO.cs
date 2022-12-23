using Entities.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Entities.DataTransferObjects
{
    public class ProductTypeDTO
    {
        public int IdProductType { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public List<ClientCycle> ClientCycles { get; set; }
    }
}
