using FastEndpoints;
using TrialDay.Dto;
using TrialDay.Pagination;
using TrialDay.Services.IServices.StudentService;

namespace TrialDay.FastEndPoints.StudentEndpoints
{
    public class GetAllEndPoint : EndpointWithoutRequest<List<StudentDto>>
    {
        private readonly IStudentService studentService;

        public GetAllEndPoint(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        public override void Configure()
        {
            Get("/api/Students");
            AllowAnonymous();
        }

        public async override Task HandleAsync(CancellationToken ct)
        {
            
                await SendAsync(await studentService.GetAllStudentsAsync());
        }
        
       

    }
}
