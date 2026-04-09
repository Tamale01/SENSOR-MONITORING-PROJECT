using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SensorMonitor.Models;

namespace SensorMonitor.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<SensorMonitor.Models.Location> Location { get; set; } = default!;
        public DbSet<SensorMonitor.Models.Sensor> Sensor { get; set; } = default!;
        public DbSet<SensorMonitor.Models.SensorData> SensorData { get; set; } = default!;
    }
}
