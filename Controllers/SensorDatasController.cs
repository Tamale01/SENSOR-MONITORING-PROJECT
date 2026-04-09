using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SensorMonitor.Data;
using SensorMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorMonitor.Controllers
{
    public class SensorDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SensorDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SensorDatas
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.SensorData.ToListAsync());
        }

        // GET: SensorDatas/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensorData = await _context.SensorData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sensorData == null)
            {
                return NotFound();
            }

            return View(sensorData);
        }

        // GET: SensorDatas/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: SensorDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SensorId,Temperature,Humidity")] SensorData sensorData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sensorData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sensorData);
        }

        // GET: SensorDatas/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensorData = await _context.SensorData.FindAsync(id);
            if (sensorData == null)
            {
                return NotFound();
            }
            return View(sensorData);
        }

        // POST: SensorDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SensorId,Temperature,Humidity")] SensorData sensorData)
        {
            if (id != sensorData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sensorData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SensorDataExists(sensorData.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sensorData);
        }

        // GET: SensorDatas/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensorData = await _context.SensorData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sensorData == null)
            {
                return NotFound();
            }

            return View(sensorData);
        }

        // POST: SensorDatas/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sensorData = await _context.SensorData.FindAsync(id);
            if (sensorData != null)
            {
                _context.SensorData.Remove(sensorData);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SensorDataExists(int id)
        {
            return _context.SensorData.Any(e => e.Id == id);
        }
    }
}
