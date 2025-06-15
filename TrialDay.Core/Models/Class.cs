using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialDay.Core.Models
{
    public class Class : BaseEntity
    {
        public string Name { get; set; }
        public string Teacher { get; set; }
        public string Decription { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
