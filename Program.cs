using IndianRestaurant.Data;
using IndianRestaurant.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var modelBuilder = WebApplication.CreateBuilder(args);
modelBuilder.Environment.EnvironmentName = "Production";

// Add services to the container.
var connectionString = modelBuilder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
modelBuilder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
modelBuilder.Services.AddDatabaseDeveloperPageExceptionFilter();

modelBuilder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
modelBuilder.Services.AddControllersWithViews();

modelBuilder.Services.AddMemoryCache();
modelBuilder.Services.AddSession(options =>
{

    options.IdleTimeout = TimeSpan.FromSeconds(10); // Set yout timeout here
});


var app = modelBuilder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
