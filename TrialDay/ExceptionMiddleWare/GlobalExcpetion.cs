using System.Net;

namespace TrialDay.ExceptionMiddleWare
{
    public  class GlobalExcpetion
    {
        private readonly ILogger<GlobalExcpetion> logger;

        public  GlobalExcpetion(ILogger<GlobalExcpetion> logger)
        {
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext http, RequestDelegate request)
        {
            try
            {
                await request(http);

            }
            catch (Exception ex) 
            {
                logger.LogError(ex, "Unhandled Exception");

                http.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                http.Response.ContentType = "application/json";

                var response = new
                {
                    Status = 500,
                    Error = ex.Message, // or customize this for production
                    Timestamp = DateTime.UtcNow
                };

                await http.Response.WriteAsJsonAsync(response);
            }




        }

    }
}

