using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SensorMonitor.Data;
using SensorMonitor.Models;
using System.Diagnostics;

namespace SensorMonitor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Fetch sensor data from SensorData table
            var sensors = await _context.SensorData.ToListAsync();

            // Labels for X-axis: using Timestamp
            var labels = sensors.Select(s => s.Timestamp.ToString("HH:mm")).ToArray();

            // Values
            var temperature = sensors.Select(s => s.Temperature).ToArray();
            var humidity = sensors.Select(s => s.Humidity).ToArray();

            // Pass to ViewBag for use in the view
            ViewBag.Labels = labels;
            ViewBag.Temperature = temperature;
            ViewBag.Humidity = humidity;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
