using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmissionManagement.Models
{
    public class StudentAdmissionDetailsModel
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentClass { get; set; }
        public DateTime DateofJoining { get; set; }
    }
}
