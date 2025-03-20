namespace WebAPI.Logging
{
    public class AuthHeaderLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AuthHeaderLoggingMiddleware> _logger;

        public AuthHeaderLoggingMiddleware(RequestDelegate next, ILogger<AuthHeaderLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                _logger.LogInformation("Authorization Header: {AuthHeader}", authHeader);
            }
            else
            {
                _logger.LogWarning("No Authorization Header found");
            }

            await _next(context);
        }
    }
}
