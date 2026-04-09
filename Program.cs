using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SensorMonitor.Data;
using SensorMonitor.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seed sample data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate(); // applies any pending migrations

    // Check if data already exists
    if (!context.SensorData.Any())
    {
        var sampleData = new List<SensorData>
        {
            new SensorData { SensorId = 1, Temperature = 24.5, Humidity = 55, Timestamp = DateTime.Parse("2026-03-31 08:00") },
            new SensorData { SensorId = 1, Temperature = 25.2, Humidity = 57, Timestamp = DateTime.Parse("2026-03-31 09:00") },
            new SensorData { SensorId = 1, Temperature = 26.0, Humidity = 60, Timestamp = DateTime.Parse("2026-03-31 10:00") },
            new SensorData { SensorId = 1, Temperature = 25.8, Humidity = 58, Timestamp = DateTime.Parse("2026-03-31 11:00") },
            new SensorData { SensorId = 1, Temperature = 27.1, Humidity = 62, Timestamp = DateTime.Parse("2026-03-31 12:00") },
            new SensorData { SensorId = 1, Temperature = 28.3, Humidity = 65, Timestamp = DateTime.Parse("2026-03-31 13:00") },
            new SensorData { SensorId = 1, Temperature = 27.5, Humidity = 63, Timestamp = DateTime.Parse("2026-03-31 14:00") },
            new SensorData { SensorId = 1, Temperature = 26.8, Humidity = 61, Timestamp = DateTime.Parse("2026-03-31 15:00") },
            new SensorData { SensorId = 1, Temperature = 25.9, Humidity = 59, Timestamp = DateTime.Parse("2026-03-31 16:00") },
            new SensorData { SensorId = 1, Temperature = 24.7, Humidity = 56, Timestamp = DateTime.Parse("2026-03-31 17:00") },
        };

        context.SensorData.AddRange(sampleData);
        context.SaveChanges();
    }
}

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
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
