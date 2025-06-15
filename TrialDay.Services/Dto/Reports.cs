using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialDay.Services.Dto
{
    public class Reports
    {
        public class StudentReportResponse
        {
            public int StudentId { get; set; }
            public List<ClassReportItem> EnrolledClasses { get; set; } = new List<ClassReportItem>();
        }

        public class ClassReportItem
        {
            public int ClassId { get; set; }
            public DateTime EnrollmentDate { get; set; }
            public List<MarkReportItem> Marks { get; set; } = new List<MarkReportItem>();
            public decimal? AverageMarksInClass { get; set; } 
        }

        public class MarkReportItem
        {
            public int MarkId { get; set; }
            public decimal Value { get; set; }
            public DateTime RecordDate { get; set; }
        }
    }
}
