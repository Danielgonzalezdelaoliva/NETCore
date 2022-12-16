using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
