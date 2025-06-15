using FastEndpoints;
using TrialDay.Services.Dto;
using TrialDay.Services.IServices.ClassService;
using TrialDay.Services.IServices.StudentService;

namespace TrialDay.FastEndPoints.ClassEndpoints
{
    public class CreateEndPoint : Endpoint<CreateClassDto>
    {
        private readonly IClassService classService;

        public CreateEndPoint(IClassService classService)
        {
            this.classService = classService;
        }
        public override void Configure()
        {
            Post("/classes");
            AllowAnonymous();
        }


        public async override Task HandleAsync(CreateClassDto req, CancellationToken ct)
        {
            await classService.CreateClassAsync(req);
            await SendAsync(new { Message = "class Created Successfully" }, StatusCodes.Status201Created);
        }
    }
}
