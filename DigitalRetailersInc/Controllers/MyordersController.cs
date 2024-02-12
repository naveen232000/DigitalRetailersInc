using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DigitalRetailersInc.Data;
using DigitalRetailersInc.Models;

namespace DigitalRetailersInc.Controllers
{
    public class MyordersController : Controller
    {
        private readonly DigitalRetailersIncContext _context;

        public MyordersController(DigitalRetailersIncContext context)
        {
            _context = context;
        }

        // GET: Myorders
        public async Task<IActionResult> Index()
        {
              return _context.Myorders != null ? 
                          View(await _context.Myorders.ToListAsync()) :
                          Problem("Entity set 'DigitalRetailersIncContext.Myorders'  is null.");
        }

        // GET: Myorders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Myorders == null)
            {
                return NotFound();
            }

            var myorders = await _context.Myorders
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (myorders == null)
            {
                return NotFound();
            }

            return View(myorders);
        }

        // GET: Myorders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Myorders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,ItemId,CustomerName,Address,PhoneNum,paymentStatus,DeleveryStatus,DateOrdered,ExpDeleveyDate")] Myorders myorders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myorders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myorders);
        }

        // GET: Myorders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Myorders == null)
            {
                return NotFound();
            }

            var myorders = await _context.Myorders.FindAsync(id);
            if (myorders == null)
            {
                return NotFound();
            }
            return View(myorders);
        }

        // POST: Myorders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,ItemId,CustomerName,Address,PhoneNum,paymentStatus,DeleveryStatus,DateOrdered,ExpDeleveyDate")] Myorders myorders)
        {
            if (id != myorders.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myorders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyordersExists(myorders.OrderId))
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
            return View(myorders);
        }

        // GET: Myorders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Myorders == null)
            {
                return NotFound();
            }

            var myorders = await _context.Myorders
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (myorders == null)
            {
                return NotFound();
            }

            return View(myorders);
        }

        // POST: Myorders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Myorders == null)
            {
                return Problem("Entity set 'DigitalRetailersIncContext.Myorders'  is null.");
            }
            var myorders = await _context.Myorders.FindAsync(id);
            if (myorders != null)
            {
                _context.Myorders.Remove(myorders);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyordersExists(int id)
        {
          return (_context.Myorders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
