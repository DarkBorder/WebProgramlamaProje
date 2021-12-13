using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnimeBox.Data;
using AnimeBox.Models;

namespace AnimeBox.Controllers
{
    public class KutuphaneController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KutuphaneController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kutuphane
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Kutuphane.Include(k => k.Hesap);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Kutuphane/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kutuphane = await _context.Kutuphane
                .Include(k => k.Hesap)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kutuphane == null)
            {
                return NotFound();
            }

            return View(kutuphane);
        }

        // GET: Kutuphane/Create
        public IActionResult Create()
        {
            ViewData["HesapId"] = new SelectList(_context.Hesap, "Id", "Id");
            return View();
        }

        // POST: Kutuphane/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnimeAd,AnimeFoto,HesapId")] Kutuphane kutuphane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kutuphane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HesapId"] = new SelectList(_context.Hesap, "Id", "Id", kutuphane.HesapId);
            return View(kutuphane);
        }

        // GET: Kutuphane/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kutuphane = await _context.Kutuphane.FindAsync(id);
            if (kutuphane == null)
            {
                return NotFound();
            }
            ViewData["HesapId"] = new SelectList(_context.Hesap, "Id", "Id", kutuphane.HesapId);
            return View(kutuphane);
        }

        // POST: Kutuphane/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnimeAd,AnimeFoto,HesapId")] Kutuphane kutuphane)
        {
            if (id != kutuphane.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kutuphane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KutuphaneExists(kutuphane.Id))
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
            ViewData["HesapId"] = new SelectList(_context.Hesap, "Id", "Id", kutuphane.HesapId);
            return View(kutuphane);
        }

        // GET: Kutuphane/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kutuphane = await _context.Kutuphane
                .Include(k => k.Hesap)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kutuphane == null)
            {
                return NotFound();
            }

            return View(kutuphane);
        }

        // POST: Kutuphane/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kutuphane = await _context.Kutuphane.FindAsync(id);
            _context.Kutuphane.Remove(kutuphane);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KutuphaneExists(int id)
        {
            return _context.Kutuphane.Any(e => e.Id == id);
        }
    }
}
