using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialDay.Services.Dto
{
    public class EnrollmentResponse
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }

    public record EnrollStudentRequest (int StudentId , int ClassId);
}
