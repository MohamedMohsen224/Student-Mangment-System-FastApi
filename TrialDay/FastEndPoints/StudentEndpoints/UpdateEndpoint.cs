using FastEndpoints;
using TrialDay.Dto;
using TrialDay.Services.IServices.StudentService;

namespace TrialDay.FastEndPoints.StudentEndpoints
{
    public class UpdateEndpoint : Endpoint<StudentDto>
    {
        private readonly IStudentService studentService;

        public UpdateEndpoint(IStudentService studentService)
        {
            this.studentService = studentService;
        }



        public override void Configure()
        {
            Put("/students");
            AllowAnonymous();
        }

        public override async Task HandleAsync(StudentDto req, CancellationToken ct)
        {
            var isUpdated = await studentService.UpdateStudentAsync(req);

            if (!isUpdated)
            {
                await SendNotFoundAsync(ct);
                return;
            }




        }
    }
    
}
