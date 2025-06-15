using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialDay.Core.Models;
using TrialDay.Core.UnitOfWork;
using TrialDay.Services.Dto;
using TrialDay.Services.IServices.EnrollmentService;

namespace TrialDay.Services.IServices.MarkService
{
    public class MarkService : IMarksService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MarkService(IUnitOfWork unitOfWork , IMapper mapper )
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<decimal?> CalculateAverageMarksForClassAsync(int classId)
        {
            var classExists = await unitOfWork.Repository<Class>().GetByIdAsync(classId);
            var marksForClass =  unitOfWork.Repository<Mark>()
                                             .GetQueryable()
                                             .Where(m => m.ClassId == classId)
                                             .Select(m => m.TotalMark) 
                                             .ToList();
            if (!marksForClass.Any())
            {
                Console.WriteLine($"No marks found for Class ID: {classId}.");
                return null;
            }

            decimal averageMarks = marksForClass.Average();
            Console.WriteLine($"Average marks for Class ID {classId}: {averageMarks:F2}");
            return averageMarks;

        }

        public async Task<MarksResponse?> RecordMarksAsync(RecordMarksRequest request)
        {
            var studentExists = await unitOfWork.Repository<Student>().GetByIdAsync(request.StudentId);
            var classExists = await unitOfWork.Repository<Class>().GetByIdAsync(request.ClassId);
            var newMarkEntity = mapper.Map<Mark>(request);
            await unitOfWork.Repository<Mark>().AddAsync(newMarkEntity);
            await unitOfWork.CompleteAsync();
            var responseDto = mapper.Map<MarksResponse>(newMarkEntity);
            Console.WriteLine($"ExamMarks {request.ExamMark} recorded for Student {request.StudentId} in Class {request.ClassId}. Mark ID: {responseDto.MarkId}");
            return responseDto;
        }
    }
}
