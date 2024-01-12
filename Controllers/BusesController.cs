using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTRS.Data;
using BTRS.Models;

namespace BTRS.Controllers
{
    public class BusesController : Controller
    {
        private readonly SystemDbContext _context;

        public BusesController(SystemDbContext context)
        {
            _context = context;
        }

        // GET: Buses
        public async Task<IActionResult> Index()
        {
              return _context.bus != null ? 
                          View(await _context.bus.ToListAsync()) :
                          Problem("Entity set 'SystemDbContext.bus'  is null.");
        }

        // GET: Buses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.bus == null)
            {
                return NotFound();
            }

            var bus = await _context.bus
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bus == null)
            {
                return NotFound();
            }

            return View(bus);
        }

        // GET: Buses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection form)
        {
            int tripId = int.Parse(form["tripId"]);
            string caption_name = form["caption_name"].ToString();
            string n_ofSeat = form["n_ofSeat"].ToString();

            Bus bus = new Bus();
            bus.caption_name = caption_name;
            bus.n_ofSeat = n_ofSeat;

            bus.trip = _context.trip.Find(tripId);

            _context.bus.Add(bus);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Buses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.bus == null)
            {
                return NotFound();
            }

            var bus = await _context.bus.FindAsync(id);
            if (bus == null)
            {
                return NotFound();
            }
            return View(bus);
        }

        // POST: Buses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,caption_name,n_ofSeat")] Bus bus)
        {
            if (id != bus.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusExists(bus.ID))
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
            return View(bus);
        }

        // GET: Buses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.bus == null)
            {
                return NotFound();
            }

            var bus = await _context.bus
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bus == null)
            {
                return NotFound();
            }

            return View(bus);
        }

        // POST: Buses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.bus == null)
            {
                return Problem("Entity set 'SystemDbContext.bus'  is null.");
            }
            var bus = await _context.bus.FindAsync(id);
            if (bus != null)
            {
                _context.bus.Remove(bus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusExists(int id)
        {
          return (_context.bus?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
