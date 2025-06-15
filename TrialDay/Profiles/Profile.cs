using AutoMapper;
using TrialDay.Core.Models;
using TrialDay.Dto;
using TrialDay.Services.Dto;

namespace TrialDay.Profiles
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {//student
            CreateMap<CreateStudentRequest, Student>();
            CreateMap<StudentDto, Student>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ReverseMap();

            //class
            CreateMap<CreateClassDto,Class>().ReverseMap();
            CreateMap<ClassDto , Class>().ReverseMap();

            //Emrollment
            CreateMap<EnrollStudentRequest, Enrollment>()
           .ForMember(dest => dest.Id, opt => opt.Ignore()) 
           .ForMember(dest => dest.EnrollmentDate, opt => opt.MapFrom(src => DateTime.UtcNow)).ReverseMap();
            CreateMap<Enrollment, EnrollmentResponse>().ReverseMap();




            CreateMap<RecordMarksRequest, Mark>().ForMember(x=>x.ExamMark , opt=>opt.MapFrom(src=>src.ExamMark))
                .ForMember(x=>x.AssigmentMark,opt=>opt.MapFrom(opt=>opt.AssigmentMark))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Mark, MarksResponse>().ForMember(x => x.ExamMark, opt => opt.MapFrom(src => src.ExamMark))
                .ForMember(x => x.AssigmentMark, opt => opt.MapFrom(opt => opt.AssigmentMark));

           

        }
    }
}
