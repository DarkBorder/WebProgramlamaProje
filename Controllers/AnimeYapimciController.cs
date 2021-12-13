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
    public class AnimeYapimciController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnimeYapimciController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AnimeYapimci
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AnimeYapimci.Include(a => a.Anime).Include(a => a.Yapimci);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AnimeYapimci/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animeYapimci = await _context.AnimeYapimci
                .Include(a => a.Anime)
                .Include(a => a.Yapimci)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animeYapimci == null)
            {
                return NotFound();
            }

            return View(animeYapimci);
        }

        // GET: AnimeYapimci/Create
        public IActionResult Create()
        {
            ViewData["AnimeId"] = new SelectList(_context.Studyo, "Id", "Id");
            ViewData["YapimciId"] = new SelectList(_context.Studyo, "Id", "Id");
            return View();
        }

        // POST: AnimeYapimci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnimeId,YapimciId")] AnimeYapimci animeYapimci)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animeYapimci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimeId"] = new SelectList(_context.Studyo, "Id", "Id", animeYapimci.AnimeId);
            ViewData["YapimciId"] = new SelectList(_context.Studyo, "Id", "Id", animeYapimci.YapimciId);
            return View(animeYapimci);
        }

        // GET: AnimeYapimci/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animeYapimci = await _context.AnimeYapimci.FindAsync(id);
            if (animeYapimci == null)
            {
                return NotFound();
            }
            ViewData["AnimeId"] = new SelectList(_context.Studyo, "Id", "Id", animeYapimci.AnimeId);
            ViewData["YapimciId"] = new SelectList(_context.Studyo, "Id", "Id", animeYapimci.YapimciId);
            return View(animeYapimci);
        }

        // POST: AnimeYapimci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnimeId,YapimciId")] AnimeYapimci animeYapimci)
        {
            if (id != animeYapimci.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animeYapimci);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimeYapimciExists(animeYapimci.Id))
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
            ViewData["AnimeId"] = new SelectList(_context.Studyo, "Id", "Id", animeYapimci.AnimeId);
            ViewData["YapimciId"] = new SelectList(_context.Studyo, "Id", "Id", animeYapimci.YapimciId);
            return View(animeYapimci);
        }

        // GET: AnimeYapimci/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animeYapimci = await _context.AnimeYapimci
                .Include(a => a.Anime)
                .Include(a => a.Yapimci)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animeYapimci == null)
            {
                return NotFound();
            }

            return View(animeYapimci);
        }

        // POST: AnimeYapimci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animeYapimci = await _context.AnimeYapimci.FindAsync(id);
            _context.AnimeYapimci.Remove(animeYapimci);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimeYapimciExists(int id)
        {
            return _context.AnimeYapimci.Any(e => e.Id == id);
        }
    }
}
