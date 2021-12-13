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
    public class YapimciController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YapimciController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Yapimci
        public async Task<IActionResult> Index()
        {
            return View(await _context.Yapimci.ToListAsync());
        }

        // GET: Yapimci/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yapimci = await _context.Yapimci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yapimci == null)
            {
                return NotFound();
            }

            return View(yapimci);
        }

        // GET: Yapimci/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yapimci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,YapimciFirmaAdi")] Yapimci yapimci)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yapimci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yapimci);
        }

        // GET: Yapimci/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yapimci = await _context.Yapimci.FindAsync(id);
            if (yapimci == null)
            {
                return NotFound();
            }
            return View(yapimci);
        }

        // POST: Yapimci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,YapimciFirmaAdi")] Yapimci yapimci)
        {
            if (id != yapimci.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yapimci);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YapimciExists(yapimci.Id))
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
            return View(yapimci);
        }

        // GET: Yapimci/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yapimci = await _context.Yapimci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yapimci == null)
            {
                return NotFound();
            }

            return View(yapimci);
        }

        // POST: Yapimci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yapimci = await _context.Yapimci.FindAsync(id);
            _context.Yapimci.Remove(yapimci);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YapimciExists(int id)
        {
            return _context.Yapimci.Any(e => e.Id == id);
        }
    }
}
