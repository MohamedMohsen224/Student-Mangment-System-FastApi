using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialDay.Core.Models;
using TrialDay.Core.UnitOfWork;
using TrialDay.Dto;
using TrialDay.Pagination;
using TrialDay.Services.Dto;

namespace TrialDay.Services.IServices.ClassService
{
    public class ClassServices : IClassService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ClassServices(IUnitOfWork unitOfWork , IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<ClassDto> CreateClassAsync(CreateClassDto dto)
        {
            if (string.IsNullOrEmpty(dto.Name))
                throw new ArgumentException("Class name is required");

            var newClass = mapper.Map<Class>(dto);
            await unitOfWork.Repository<Class>().AddAsync(newClass);
            await unitOfWork.CompleteAsync();

            return mapper.Map<ClassDto>(newClass);
        }

        public async Task<List<ClassDto>> GetAllClassesAsync(string? searchTerm = null)
        {
            var allClasses = await unitOfWork.Repository<Class>().GetAllAsync();

            IEnumerable<Class> query = allClasses;

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(c =>
                    (c.Name != null && c.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                    (c.Teacher != null && c.Teacher.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                );
            }

            return mapper.Map<List<ClassDto>>(query.ToList());
        }


        public async Task<bool> DeleteClassAsync(int ClassId)
        {
            var classs = await unitOfWork.Repository<Class>()
                .GetByIdAsync(ClassId);

            if (classs == null)
                return false;

            unitOfWork.Repository<Class>().DeleteAsync(classs);
            return true;
        }
    }
}
