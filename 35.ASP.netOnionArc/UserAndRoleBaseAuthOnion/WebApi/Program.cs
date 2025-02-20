using Infrastructure.Data;
using Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

try
{
    using var scope = app.Services.CreateScope();
    await DbInitializer.InitializeAsync(app.Services);
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred during database initialization: {ex.Message}");
    Console.WriteLine(ex.StackTrace);
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
