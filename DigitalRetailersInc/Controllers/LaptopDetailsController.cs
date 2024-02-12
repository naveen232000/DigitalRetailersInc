using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DigitalRetailersInc.Data;
using DigitalRetailersInc.Models;
using Microsoft.AspNetCore.Authorization;

namespace DigitalRetailersInc.Controllers
{
    [Authorize]
    public class LaptopDetailsController : Controller
    {
        private readonly DigitalRetailersIncContext _context;

        public LaptopDetailsController(DigitalRetailersIncContext context)
        {
            _context = context;
        }

        // GET: LaptopDetails
        public async Task<IActionResult> Index()
        {
              return _context.LaptopDetails != null ? 
                          View(await _context.LaptopDetails.ToListAsync()) :
                          Problem("Entity set 'DigitalRetailersIncContext.LaptopDetails'  is null.");
        }

        // GET: LaptopDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LaptopDetails == null)
            {
                return NotFound();
            }

            var laptopDetails = await _context.LaptopDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laptopDetails == null)
            {
                return NotFound();
            }

            return View(laptopDetails);
        }

        // GET: LaptopDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LaptopDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Price,Img")] LaptopDetails laptopDetails)
        {
           
            if (!ModelState.IsValid)
            {
                var files = Request.Form.Files;

                if (files.Count > 0)
                {

                    using (var filestream = files[0].OpenReadStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            filestream.CopyTo(memoryStream);
                            laptopDetails.Img = memoryStream.ToArray();
                        }
                    }
                }
                try
                {
                    _context.Add(laptopDetails);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error occurred while saving data: " + ex.Message);
                    // Log the exception for debugging purposes
                }

                return RedirectToAction(nameof(Index));
                
            }
         
           
            return View(laptopDetails);
        }


        // GET: LaptopDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LaptopDetails == null)
            {
                return NotFound();
            }

            var laptopDetails = await _context.LaptopDetails.FindAsync(id);
            if (laptopDetails == null)
            {
                return NotFound();
            }
            return View(laptopDetails);
        }

        // POST: LaptopDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Price,Img")] LaptopDetails laptopDetails)
        {
            if (id != laptopDetails.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)

            {
                var files = Request.Form.Files;

                if (files.Count > 0)
                {

                    using (var filestream = files[0].OpenReadStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            filestream.CopyTo(memoryStream);
                            laptopDetails.Img = memoryStream.ToArray();
                        }
                    }
                }
                try
                {
                    _context.Update(laptopDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaptopDetailsExists(laptopDetails.Id))
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
            return View(laptopDetails);
        }

        // GET: LaptopDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LaptopDetails == null)
            {
                return NotFound();
            }

            var laptopDetails = await _context.LaptopDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laptopDetails == null)
            {
                return NotFound();
            }

            return View(laptopDetails);
        }

        // POST: LaptopDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LaptopDetails == null)
            {
                return Problem("Entity set 'DigitalRetailersIncContext.LaptopDetails'  is null.");
            }
            var laptopDetails = await _context.LaptopDetails.FindAsync(id);
            if (laptopDetails != null)
            {
                _context.LaptopDetails.Remove(laptopDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaptopDetailsExists(int id)
        {
          return (_context.LaptopDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
