using FastEndpoints;
using TrialDay.Dto;
using TrialDay.Services.IServices.ClassService;
using TrialDay.Services.IServices.StudentService;

namespace TrialDay.FastEndPoints.ClassEndpoints
{
    public class DeleteEndpoint : EndpointWithoutRequest
    {
        private readonly IClassService classService;

        public DeleteEndpoint(IClassService classService)
        {
            this.classService = classService;
        }

        public override void Configure()
        {
            Delete("DeleteClass/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var id = Route<int>("id");

            Console.WriteLine($"Attempting to delete class with ID: {id}");

            var result = await classService.DeleteClassAsync(id);

            if (result)
            {
              SendAsync( new { Message = "class Deleted Successfully" },StatusCodes.Status200OK);
            }
            else
            {

                await SendNotFoundAsync(ct);
            }
        }
    }
}
