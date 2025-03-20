using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WebAPI.Logging
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        //public async Task Invoke(HttpContext context)
        //{
        //    var requestBody = await ReadRequestBody(context);
        //    _logger.LogInformation("Incoming Request: {Method} {Path}\nBody: {Body}",
        //        context.Request.Method, context.Request.Path, requestBody);

        //    var originalResponseBodyStream = context.Response.Body;
        //    var responseBodyStream = new MemoryStream();
        //    context.Response.Body = responseBodyStream;

        //    try
        //    {
        //        await _next(context);

        //        responseBodyStream.Seek(0, SeekOrigin.Begin);
        //        var responseBody = await new StreamReader(responseBodyStream).ReadToEndAsync();

        //        _logger.LogInformation("Response Status: {StatusCode}\nBody: {Body}",
        //            context.Response.StatusCode, responseBody);

        //        responseBodyStream.Seek(0, SeekOrigin.Begin);
        //        await responseBodyStream.CopyToAsync(originalResponseBodyStream);
        //    }
        //    finally
        //    {
        //        context.Response.Body = originalResponseBodyStream;
        //        responseBodyStream.Dispose();
        //    }
        //}

        //private async Task<string> ReadRequestBody(HttpContext context)
        //{
        //    context.Request.EnableBuffering();
        //    using var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true);
        //    var body = await reader.ReadToEndAsync();
        //    context.Request.Body.Position = 0;
        //    return string.IsNullOrWhiteSpace(body) ? "[Empty]" : body;
        //}
    }
}