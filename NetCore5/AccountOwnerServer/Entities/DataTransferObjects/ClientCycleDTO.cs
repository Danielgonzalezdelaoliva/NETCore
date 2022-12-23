using Entities.Models;
using System;

namespace Entities.DataTransferObjects
{
    public class ClientCycleDTO
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
       
        public ProductType ProductType { get; set; }
    }
}
