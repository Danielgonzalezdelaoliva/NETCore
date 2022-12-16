using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    //[Table("cca_clientcycle", Schema = "cca")]
    [Table("cca_clientcycle")]
    public class ClientCycle
    {
        public int IdClientBase { get; set; }

        public DateTime? Date { get; set; }

        public string Review { get; set; }

        public string Model { get; set; }

        public string CIMTO { get; set; }

        public string Installation { get; set; }

        public string Author { get; set; }

        public string Notes { get; set; }

        public string vVersion { get; set; }

        public int IdCycle { get; set; }

        public int IdProductType { get; set; }

        public DateTime? DateLastUpd { get; set; }

        public Client Client { get; set; }

        public ProductType ProductType { get; set; }
        
    }
}
