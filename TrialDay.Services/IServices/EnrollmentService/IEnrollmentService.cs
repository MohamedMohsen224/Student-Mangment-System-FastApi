using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialDay.Services.Dto;

namespace TrialDay.Services.IServices.EnrollmentService
{
    public interface IEnrollmentService
    {
        public Task<EnrollmentResponse?> EnrollStudentAsync(EnrollStudentRequest enrollmentResponse);
    }
}
