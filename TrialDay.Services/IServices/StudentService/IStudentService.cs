using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialDay.Core.Models;
using TrialDay.Dto;
using TrialDay.Pagination;
using TrialDay.Services.Dto;
using static TrialDay.Services.Dto.Reports;

namespace TrialDay.Services.IServices.StudentService
{
    public interface IStudentService
    {
        public Task CreateStudentAsync(CreateStudentRequest request);

        public Task<List<StudentDto>> GetAllStudentsAsync(string? searchTerm = null);

        public Task<bool> DeleteStudentAsync(int studentId);

        Task<bool> UpdateStudentAsync(StudentDto studentDto);



    }
}
