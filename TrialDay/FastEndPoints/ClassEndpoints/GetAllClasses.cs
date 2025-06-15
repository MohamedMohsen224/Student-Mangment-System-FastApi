using FastEndpoints;
using TrialDay.Services.Dto;
using TrialDay.Services.IServices.ClassService;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrialDay.FastEndPoints.ClassEndpoints
{
    public class GetAllClasses : EndpointWithoutRequest<List<ClassDto>>
    {
        private readonly IClassService classService;

        public GetAllClasses(IClassService classService)
        {
            this.classService = classService;
        }


        public override void Configure()
        {
            Get("/api/classes");
            AllowAnonymous();
        }

        public async override Task HandleAsync(CancellationToken ct)
        {
            await SendAsync(await classService.GetAllClassesAsync());

        }
    }
}
