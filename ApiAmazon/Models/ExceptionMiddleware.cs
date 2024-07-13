using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ApiAmazon.Models
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate request;

        public ExceptionMiddleware(RequestDelegate _request)
        {
            request = _request;
        }

        public async Task InvokeAsync (HttpContext context)
        {
            try
            {
                await request(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var error = new ErrorDetails
                {
                    Title = "Error in the Application code",
                    Status = "InternalServerError"
                };

                var Result = JsonConvert.SerializeObject(error);
                await context.Response.WriteAsync(Result);
            }
        }
    }
}
