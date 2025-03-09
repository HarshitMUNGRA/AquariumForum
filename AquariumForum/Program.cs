using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AquariumForum.Data;
using AquariumForum.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure DbContext to use SQLite
builder.Services.AddDbContext<AquariumForumContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("AquariumForumContext")
        ?? throw new InvalidOperationException("Connection string 'AquariumForumContext' not found.")));

// Add Identity services
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AquariumForumContext>();

// Add MVC controllers and views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication(); // <- Add this to enable Identity authentication
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages().WithStaticAssets();
app.Run();
