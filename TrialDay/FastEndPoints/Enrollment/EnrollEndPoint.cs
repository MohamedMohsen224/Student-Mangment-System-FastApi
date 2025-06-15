using FastEndpoints;
using TrialDay.Core.Models;
using TrialDay.Services.Dto;
using TrialDay.Services.IServices.EnrollmentService;

namespace TrialDay.FastEndPoints.Enrollment
{
    public class EnrollEndPoint : Endpoint<EnrollStudentRequest, EnrollmentResponse>
    {
        private readonly IEnrollmentService enrollmentService;

        public EnrollEndPoint(IEnrollmentService enrollmentService)
        {
            this.enrollmentService = enrollmentService;
        }

        public override void Configure()
        {
            Post("EnrollStudent");
            AllowAnonymous();
        }

        public async override Task HandleAsync(EnrollStudentRequest req, CancellationToken ct)
        {
            var newEnrollmentResponse = await enrollmentService.EnrollStudentAsync(req);

            if (newEnrollmentResponse != null)
            {

                await SendCreatedAtAsync($"/api/enrollments/{newEnrollmentResponse.EnrollmentId}", newEnrollmentResponse.EnrollmentId, newEnrollmentResponse, cancellation: ct);
            }
            else
            {
                AddError("Enrollment failed. Please check student ID, class ID, and ensure no duplicate enrollment exists.");
                await SendErrorsAsync(StatusCodes.Status400BadRequest, ct);
            }
        }
    }
}
