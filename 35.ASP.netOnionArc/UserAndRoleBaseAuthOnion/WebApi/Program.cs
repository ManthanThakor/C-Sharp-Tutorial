using Application.Services.AuthServ;
using Application.Services.PasswordService;
using Application.Services.TokenService;
using Application.Services.UserSer;
using Infrastructure.Data;
using Infrastructure.EfCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Configure Database Connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 Register Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();

// 🔹 Configure CORS Policy (For frontend communication)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.WithOrigins("https://localhost:7131") // Adjust as per your frontend URL
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials(); // Allow cookies & credentials
        });
});

// 🔹 Configure JWT Authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["Secret"];

if (string.IsNullOrEmpty(secretKey))
    throw new Exception("JWT Secret key is missing from configuration.");

var key = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

// 🔹 Add Authorization
builder.Services.AddAuthorization();

// 🔹 Add Controllers
builder.Services.AddControllers();

// 🔹 Allow Access to HttpContext
builder.Services.AddHttpContextAccessor();

// 🔹 Configure Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // 🔹 Add JWT Authentication to Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer <your-token>'",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

// 🔹 Enable Swagger in Development Mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🔹 Enable HTTPS Redirection
app.UseHttpsRedirection();

// 🔹 Apply CORS Policy
app.UseCors("AllowAll");

// 🔹 Apply Cookie Policy
app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.None, // Required for cross-origin requests
    HttpOnly = HttpOnlyPolicy.Always, // Prevent JavaScript from accessing cookies
    Secure = CookieSecurePolicy.Always // Cookies only sent over HTTPS
});

// 🔹 Enable Authentication & Authorization Middleware
app.UseAuthentication();
app.UseAuthorization();

// 🔹 Map Controllers
app.MapControllers();

// 🔹 Database Initialization
try
{
    using var scope = app.Services.CreateScope();
    var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
    await dbInitializer.InitializeAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred during database initialization: {ex.Message}");
    Console.WriteLine(ex.StackTrace);
}

// 🔹 Run Application
app.Run();
