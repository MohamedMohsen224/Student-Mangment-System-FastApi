using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialDay.Services.Dto
{
    public record ClassDto
    {
        public string Name { get; set; }
        public string Teacher { get; set; }
        public string Decription { get; set; }
    };


   public record CreateClassDto
    {
        public string Name { get; set; }
        public string Teacher { get; set; }
        public string Decription { get; set; }
    };

    public record DeleteReq (int id);
}
