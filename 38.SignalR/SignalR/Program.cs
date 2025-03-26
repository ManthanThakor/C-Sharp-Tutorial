using SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Add CORS to allow frontend clients
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:5500", "http://127.0.0.1:5500", "https://localhost:7141")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});


// ✅ Add SignalR Service
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

// ✅ Map SignalR Hub
app.MapHub<ChatHub>("/chatHub");

app.Run();
