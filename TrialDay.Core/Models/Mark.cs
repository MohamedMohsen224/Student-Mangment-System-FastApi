using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialDay.Core.Models
{
    public class Mark : BaseEntity
    {
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public decimal ExamMark { get; set; }
        public decimal AssigmentMark { get; set;}

        public decimal TotalMark => ExamMark + AssigmentMark;

    }
}
