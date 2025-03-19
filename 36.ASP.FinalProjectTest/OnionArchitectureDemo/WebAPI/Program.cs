using WebAPI.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.AddConsole(); // Enable Console Logging

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // 🔹 Ensure HTTPS redirection first

app.UseMiddleware<RequestLoggingMiddleware>(); // 🔹 Use Logging Middleware

app.UseAuthorization();

app.MapControllers(); // 🔹 Single controller mapping

app.Run();
