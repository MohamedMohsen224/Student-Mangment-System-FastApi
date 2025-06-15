using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialDay.Core.Models
{
    public class Enrollment : BaseEntity
    {
        public int studentId { get; set; }
        public int ClassId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Student Student { get; set; }
        public Class Class { get; set; }
    }
}
