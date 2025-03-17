using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using InfrastructureLayer.Service.CustomServices.SupplierServices;
using WebAPI.Middleware.Auth;
using Infrastructure.Repository;
using InfrastructureLayer.Repository;
using Domain.Models;
using InfrastructureLayer.Service.CustomServices.UserTypeServices;
using Infrastructure.Services.CustomServices.ItemServices;
using InfrastructureLayer.Service.CustomServices.CategoryServices;
using InfrastructureLayer.Service.CustomServices.CustomerServices;
using InfrastructureLayer.Service.CustomServices.ItemServices;
using InfrastructureLayer.Service.GeneralServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 Register Auth services
builder.Services.AddScoped<IJWTAuthManager, JWTAuthManager>();

// Register Generic Repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Register Specific Services
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IUserTypeService, UserTypeService>();

// Register Generic Service
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
