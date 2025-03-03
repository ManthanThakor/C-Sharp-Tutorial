using ApplicationLayer.InterfaceService;
using ApplicationLayer.Services;
using InfrastructureLayer.Data;
using InfrastructureLayer.InterfaceRepo;
using InfrastructureLayer.Utilities;
using Microsoft.EntityFrameworkCore;
using InfrastructureLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<ITokenService, TokenService>();

// Register Repositories
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

var app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
    IServiceProvider services = scope.ServiceProvider;
    AppDbContext context = services.GetRequiredService<AppDbContext>();
    IPasswordService passwordService = services.GetRequiredService<IPasswordService>();

    DbInitializer.Initialize(context, passwordService);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
