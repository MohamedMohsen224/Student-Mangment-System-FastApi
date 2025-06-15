using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialDay.Core.Models;
using TrialDay.Core.UnitOfWork;
using TrialDay.Services.Dto;

namespace TrialDay.Services.IServices.EnrollmentService
{
    public class EnrollStudentService : IEnrollmentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public EnrollStudentService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<EnrollmentResponse?> EnrollStudentAsync(EnrollStudentRequest enrollmentResponse)
        {
            var studentExists = await unitOfWork.Repository<Student>().GetByIdAsync(enrollmentResponse.StudentId);
            var classExists = await unitOfWork.Repository<Class>().GetByIdAsync(enrollmentResponse.ClassId);

            if (studentExists == null)
            {
                Console.WriteLine($"Student with ID {enrollmentResponse.StudentId} not found.");
                return null;
            }

            if (classExists == null)
            {
                Console.WriteLine($"Class with ID {enrollmentResponse.ClassId} not found.");
                return null;
            }
            var newEnrollment = mapper.Map<Enrollment>(enrollmentResponse);
            var responseDto = mapper.Map<EnrollmentResponse>(newEnrollment);
            await unitOfWork.Repository<Enrollment>().AddAsync(newEnrollment);
            await unitOfWork.CompleteAsync();
            return responseDto;



        }
    }
}
