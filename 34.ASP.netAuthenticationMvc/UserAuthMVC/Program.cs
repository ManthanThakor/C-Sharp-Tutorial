using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Security.Cryptography;
using UserAuthMVC.EFcore;
using UserAuthMVC.Models.ViewModels;
using UserAuthMVC.Models;
using UserAuthMVC.Repository.IRepo;
using UserAuthMVC.Repository.Utilitie;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

// Configure DbContext with SQL Server connection string
builder.Services.AddDbContext<CookieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepo, UserRepo>();

builder.Services.AddScoped<IUserManager, UserManager>();

// Optionally, add configuration for authentication (cookie-based authentication)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        //options.LoginPath = "/Account/Login";
        //options.LogoutPath = "/Account/Logout";
        //options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        //options.SlidingExpiration = true;
    });

// Configure other required services like user session handling, etc.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // Default HSTS value is 30 days. Change this for production.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



