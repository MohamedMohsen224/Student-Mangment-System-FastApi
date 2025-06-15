using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialDay.Services.Dto;

namespace TrialDay.Services.IServices.MarkService
{
    public interface IMarksService
    {
        Task<MarksResponse?> RecordMarksAsync(RecordMarksRequest request);
        Task<decimal?> CalculateAverageMarksForClassAsync(int classId);


    }
}
