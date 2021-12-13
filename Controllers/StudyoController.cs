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
    public class StudyoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudyoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Studyo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Studyo.ToListAsync());
        }

        // GET: Studyo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyo = await _context.Studyo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studyo == null)
            {
                return NotFound();
            }

            return View(studyo);
        }

        // GET: Studyo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Studyo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudyoAdi")] Studyo studyo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studyo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studyo);
        }

        // GET: Studyo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyo = await _context.Studyo.FindAsync(id);
            if (studyo == null)
            {
                return NotFound();
            }
            return View(studyo);
        }

        // POST: Studyo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudyoAdi")] Studyo studyo)
        {
            if (id != studyo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studyo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudyoExists(studyo.Id))
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
            return View(studyo);
        }

        // GET: Studyo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyo = await _context.Studyo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studyo == null)
            {
                return NotFound();
            }

            return View(studyo);
        }

        // POST: Studyo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studyo = await _context.Studyo.FindAsync(id);
            _context.Studyo.Remove(studyo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudyoExists(int id)
        {
            return _context.Studyo.Any(e => e.Id == id);
        }
    }
}
