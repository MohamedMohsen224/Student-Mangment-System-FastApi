using FastEndpoints;
using TrialDay.Dto;
using TrialDay.Services.IServices.StudentService;

namespace TrialDay.FastEndPoints.StudentEndpoints
{
    public class DeleteEndPoint : Endpoint<DeleteReq>
    {
        private readonly IStudentService studentService;

        public DeleteEndPoint(IStudentService studentService)
        {
            this.studentService = studentService;
        }


        public override void Configure()
        {
            Delete("/DeleteStudents/{Id}");
            AllowAnonymous();
        }
        public async override Task HandleAsync(DeleteReq req, CancellationToken ct)
        {
            var id = Route<int>("id");

            Console.WriteLine($"Attempting to delete class with ID: {id}");

            var result = await studentService.DeleteStudentAsync(id);

            if (result)
            {
                SendAsync(new { Message = "Student Deleted Successfully" }, StatusCodes.Status200OK);
            }
            else
            {

                await SendNotFoundAsync(ct);
            }
        }
     }
}
