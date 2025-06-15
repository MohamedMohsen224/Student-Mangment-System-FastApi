using FastEndpoints;
using TrialDay.Services.Dto;
using TrialDay.Services.IServices.MarkService;

namespace TrialDay.FastEndPoints.RecordEndPoints
{
    public class RecordEndPoints : Endpoint<RecordMarksRequest, MarksResponse>
    {
        private readonly IMarksService marksService;

        public RecordEndPoints(IMarksService marksService)
        {
            this.marksService = marksService;
        }
        public override void Configure()
        {
            Post("/api/marks");
            AllowAnonymous();
        }


        public async override Task HandleAsync(RecordMarksRequest req, CancellationToken ct)
        {
            var newMarksResponse = await marksService.RecordMarksAsync(req);

            if (newMarksResponse != null)
            {
              
                await SendCreatedAtAsync($"/api/marks/{newMarksResponse.MarkId}", newMarksResponse.MarkId, newMarksResponse, cancellation: ct);
            }
            else
            {
               
                AddError("Mark recording failed. Please check student ID, class ID, and ensure the student is enrolled.");
                await SendErrorsAsync(StatusCodes.Status400BadRequest, ct);
            }
        }

    }
}
