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
    public class HesapController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HesapController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hesap
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Hesap.Include(h => h.Kutuphane).Include(h => h.Sepet);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Hesap/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hesap = await _context.Hesap
                .Include(h => h.Kutuphane)
                .Include(h => h.Sepet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hesap == null)
            {
                return NotFound();
            }

            return View(hesap);
        }

        // GET: Hesap/Create
        public IActionResult Create()
        {
            ViewData["KutuphaneId"] = new SelectList(_context.Hesap, "Id", "Id");
            ViewData["SepetId"] = new SelectList(_context.Hesap, "Id", "Id");
            return View();
        }

        // POST: Hesap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SepetId,KutuphaneId,Ad,SoyAd,Email,KayitTarihi")] Hesap hesap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hesap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KutuphaneId"] = new SelectList(_context.Hesap, "Id", "Id", hesap.KutuphaneId);
            ViewData["SepetId"] = new SelectList(_context.Hesap, "Id", "Id", hesap.SepetId);
            return View(hesap);
        }

        // GET: Hesap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hesap = await _context.Hesap.FindAsync(id);
            if (hesap == null)
            {
                return NotFound();
            }
            ViewData["KutuphaneId"] = new SelectList(_context.Hesap, "Id", "Id", hesap.KutuphaneId);
            ViewData["SepetId"] = new SelectList(_context.Hesap, "Id", "Id", hesap.SepetId);
            return View(hesap);
        }

        // POST: Hesap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SepetId,KutuphaneId,Ad,SoyAd,Email,KayitTarihi")] Hesap hesap)
        {
            if (id != hesap.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hesap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HesapExists(hesap.Id))
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
            ViewData["KutuphaneId"] = new SelectList(_context.Hesap, "Id", "Id", hesap.KutuphaneId);
            ViewData["SepetId"] = new SelectList(_context.Hesap, "Id", "Id", hesap.SepetId);
            return View(hesap);
        }

        // GET: Hesap/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hesap = await _context.Hesap
                .Include(h => h.Kutuphane)
                .Include(h => h.Sepet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hesap == null)
            {
                return NotFound();
            }

            return View(hesap);
        }

        // POST: Hesap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hesap = await _context.Hesap.FindAsync(id);
            _context.Hesap.Remove(hesap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HesapExists(int id)
        {
            return _context.Hesap.Any(e => e.Id == id);
        }
    }
}
