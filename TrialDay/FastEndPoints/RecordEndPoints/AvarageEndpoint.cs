using FastEndpoints;
using TrialDay.Services.IServices.MarkService;

namespace TrialDay.FastEndPoints.RecordEndPoints
{
    public class AvarageEndpoint : EndpointWithoutRequest<decimal?>
    {
        private readonly IMarksService _marksService;

        public AvarageEndpoint(IMarksService marksService)
        {
            _marksService = marksService;
        }

        public override void Configure()
        {
            Get("/api/classes/{classId}/average-marks"); 
            AllowAnonymous(); 
           
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var classId = Route<int>("classId");

            if (classId <= 0)
            {
                AddError("Class ID must be a positive number.");
                await SendErrorsAsync(StatusCodes.Status400BadRequest, ct);
                return;
            }

            var averageMarks = await _marksService.CalculateAverageMarksForClassAsync(classId);

            if (averageMarks.HasValue)
            {
                await SendOkAsync(averageMarks.Value, ct);
            }
            else
            {
                await SendNotFoundAsync(ct);
            }
        }
    }
}
