using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    //[Table("cca_producttype", Schema = "cca")]
    [Table("cca_producttype")]
    public class ProductType
    {
        public int IdProductType { get; set; }

        public string Name { get; set; }
       
        public List<ClientCycle> ClientCycles { get; set; }
    }
}
