using FastEndpoints;
using TrialDay.Core.Models;
using TrialDay.Dto;
using TrialDay.Services.IServices.StudentService;

namespace TrialDay.FastEndPoints.StudentEndpoints
{
    public class CreateEndPoints :Endpoint<CreateStudentRequest> 
    {
        private readonly IStudentService studentService;

        public CreateEndPoints(IStudentService studentService)
        {
            this.studentService = studentService;
        }


        public override void Configure()
        {
            Post("/students");
            AllowAnonymous();
        }


        public async override Task HandleAsync(CreateStudentRequest req, CancellationToken ct)
        {
            await studentService.CreateStudentAsync(req);
            await SendAsync(new { Message = "Student Created Successfully" }, StatusCodes.Status201Created);
        }
    }
}
