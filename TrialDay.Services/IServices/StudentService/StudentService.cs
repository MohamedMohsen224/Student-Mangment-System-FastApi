using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialDay.Core.Models;
using TrialDay.Core.UnitOfWork;
using TrialDay.Dto;
using TrialDay.Pagination;
using TrialDay.Services.Dto;
using static TrialDay.Services.Dto.Reports;
using TrialDay.Services.IServices.EnrollmentService;

namespace TrialDay.Services.IServices.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public StudentService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public async Task CreateStudentAsync(CreateStudentRequest request)
        {
            var student = mapper.Map<Student>(request);
            await unitOfWork.Repository<Student>().AddAsync(student);
        }

        public void DeleteStudentAsync(Student student)
        {
            var stud =  unitOfWork.Repository<Student>().GetByIdAsync(student.Id);
            if (stud is not null)
            {
                unitOfWork.Repository<Student>().DeleteAsync(student);
            }
        }

        public async Task<bool> UpdateStudentAsync(StudentDto studentDto)
        {
            var existingStudent = await unitOfWork.Repository<Student>()
                .GetByIdAsync(studentDto.id);

            if (existingStudent is null)
                return false;

            mapper.Map(studentDto, existingStudent);
            unitOfWork.Repository<Student>().UpdateAsync(existingStudent);

            return true;
        }

        public async Task<bool> DeleteStudentAsync(int studentId)
        {
            var student = await unitOfWork.Repository<Student>()
                .GetByIdAsync(studentId);

            if (student == null)
                return false;

            unitOfWork.Repository<Student>().DeleteAsync(student);
            return true;
        }

        public async Task<List<StudentDto>> GetAllStudentsAsync(string? searchTerm = null)
        {
            var AllStudents = await unitOfWork.Repository<Student>().GetAllAsync();

            IEnumerable<Student> query = AllStudents;

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(c =>
                    (c.FirstName != null && c.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                    (c.LastName != null && c.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                );
            }

            return mapper.Map<List<StudentDto>>(query.ToList());
        }

       
    }
}
