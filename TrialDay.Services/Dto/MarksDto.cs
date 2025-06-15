using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialDay.Services.Dto
{
    public record MarksDto
    {
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public decimal AssigmentMark { get; set; }
        public decimal ExamMark { get; set; }

    }

    public class MarksResponse
    {
        public int MarkId { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public decimal AssigmentMark { get; set; }
        public decimal ExamMark { get; set; }

    }

    public class RecordMarksRequest
    {
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public decimal AssigmentMark { get; set; }
        public decimal ExamMark { get; set; }

    }
}
