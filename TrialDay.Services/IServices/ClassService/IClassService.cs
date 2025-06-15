using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialDay.Pagination;
using TrialDay.Services.Dto;

namespace TrialDay.Services.IServices.ClassService
{
    public interface IClassService
    {
        Task<ClassDto> CreateClassAsync(CreateClassDto dto);
        public Task<List<ClassDto>> GetAllClassesAsync(string? searchTerm = null);
        public Task<bool> DeleteClassAsync(int studentId);

    }

}
