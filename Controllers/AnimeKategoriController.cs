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
    public class AnimeKategoriController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnimeKategoriController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AnimeKategori
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AnimeKategori.Include(a => a.Anime).Include(a => a.Kategori);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AnimeKategori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animeKategori = await _context.AnimeKategori
                .Include(a => a.Anime)
                .Include(a => a.Kategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animeKategori == null)
            {
                return NotFound();
            }

            return View(animeKategori);
        }

        // GET: AnimeKategori/Create
        public IActionResult Create()
        {
            ViewData["AnimeId"] = new SelectList(_context.Studyo, "Id", "Id");
            ViewData["KategoriId"] = new SelectList(_context.Studyo, "Id", "Id");
            return View();
        }

        // POST: AnimeKategori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnimeId,KategoriId,OnemSirasi")] AnimeKategori animeKategori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animeKategori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimeId"] = new SelectList(_context.Studyo, "Id", "Id", animeKategori.AnimeId);
            ViewData["KategoriId"] = new SelectList(_context.Studyo, "Id", "Id", animeKategori.KategoriId);
            return View(animeKategori);
        }

        // GET: AnimeKategori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animeKategori = await _context.AnimeKategori.FindAsync(id);
            if (animeKategori == null)
            {
                return NotFound();
            }
            ViewData["AnimeId"] = new SelectList(_context.Studyo, "Id", "Id", animeKategori.AnimeId);
            ViewData["KategoriId"] = new SelectList(_context.Studyo, "Id", "Id", animeKategori.KategoriId);
            return View(animeKategori);
        }

        // POST: AnimeKategori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnimeId,KategoriId,OnemSirasi")] AnimeKategori animeKategori)
        {
            if (id != animeKategori.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animeKategori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimeKategoriExists(animeKategori.Id))
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
            ViewData["AnimeId"] = new SelectList(_context.Studyo, "Id", "Id", animeKategori.AnimeId);
            ViewData["KategoriId"] = new SelectList(_context.Studyo, "Id", "Id", animeKategori.KategoriId);
            return View(animeKategori);
        }

        // GET: AnimeKategori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animeKategori = await _context.AnimeKategori
                .Include(a => a.Anime)
                .Include(a => a.Kategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animeKategori == null)
            {
                return NotFound();
            }

            return View(animeKategori);
        }

        // POST: AnimeKategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animeKategori = await _context.AnimeKategori.FindAsync(id);
            _context.AnimeKategori.Remove(animeKategori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimeKategoriExists(int id)
        {
            return _context.AnimeKategori.Any(e => e.Id == id);
        }
    }
}
