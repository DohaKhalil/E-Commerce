using System.Net;
using System.Text.Json;

namespace E_Commerce.APIError
{
    public class CostomeExceptionHandler
    {
        private readonly RequestDelegate _next; // next to 
        private readonly ILogger<CostomeExceptionHandler> _logger;
        private readonly IHostEnvironment _environment;

        public CostomeExceptionHandler(RequestDelegate next, ILogger<CostomeExceptionHandler> logger , IHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext _context)
        {
            try
            {
                await _next.Invoke(_context);

            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _context.Response.StatusCode =(int) HttpStatusCode.InternalServerError;
                var ResponseError = _environment.IsDevelopment() ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace)
                : new ApiException((int)HttpStatusCode.InternalServerError);
                //var json = JsonSerializer.Serialize(ResponseError , new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase} );
                //await _context.Response.WriteAsync(json);
                await _context.Response.WriteAsJsonAsync(ResponseError);
            }

        }
    }
}
