using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using CustomerSupportApp.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CustomerSupportAppContextConnection") ?? throw new InvalidOperationException("Connection string 'CustomerSupportAppContextConnection' not found.");

builder.Services.AddDbContext<CustomerSupportAppContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<CustomerSupportAppContext>();

// Database Connection
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//// Add Identity
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
//    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add Controllers and Views
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Configure SignalR
builder.Services.AddSignalR();

var app = builder.Build();

// Middleware Setup
app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//    endpoints.MapRazorPages();
//    endpoints.MapHub<ChatHub>("/chatHub");
//});

app.Run();

