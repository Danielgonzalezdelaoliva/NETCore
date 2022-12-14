using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceManagement.Models
{
    public class StudentAttendanceDetailsModel
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public double AttendencePercentage { get; set; }
    }
}
