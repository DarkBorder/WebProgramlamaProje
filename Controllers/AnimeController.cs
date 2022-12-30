using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnimeBox.Data;
using AnimeBox.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace AnimeBox.Controllers
{
    public class AnimeController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _hostingEnvironment;


       public AnimeController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostEnvironment;
        }

        // GET: Anime
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Anime.Include(a => a.Studyo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Anime/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime = await _context.Anime
                .Include(a => a.Studyo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        // GET: Anime/Create
        public IActionResult Create()
        {
            ViewData["StudyoId"] = new SelectList(_context.Studyo, "Id", "StudyoAdi");
            return View();
        }

        // POST: Anime/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudyoId,AnimeAdi,BaslamaTarihi,BitisTarihi,KacBolumTamamlandi,HangiSezondaCikti,SezonNo,PartNo,Fiyat,YasSiniri,SatinAlimSayisi,IzlenmeSayisi,BegeniSayisi,BolumSayisi,BolumSuresi,IMDB_Puan,AktifMi,AnimeninKonusu,AnimeTanitimFoto,AnimeKucukFoto,FragmanVideosu")] Anime anime)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"lib/bootstrap/dist/img/anime/");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension),FileMode.Create)) 
                {
                    files[0].CopyTo(fileStream);
                }
                anime.AnimeTanitimFoto = @"lib/bootstrap/dist/img/anime/" + fileName + extension;

                _context.Add(anime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["StudyoId"] = new SelectList(_context.Studyo, "Id", "StudyoAdi", anime.StudyoId);
            return View(anime);
        }

        // GET: Anime/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime = await _context.Anime.FindAsync(id);
            if (anime == null)
            {
                return NotFound();
            }
            ViewData["StudyoId"] = new SelectList(_context.Studyo, "Id", "StudyoAdi", anime.StudyoId);
            return View(anime);
        }

        // POST: Anime/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudyoId,AnimeAdi,BaslamaTarihi,BitisTarihi,KacBolumTamamlandi,HangiSezondaCikti,SezonNo,PartNo,Fiyat,YasSiniri,SatinAlimSayisi,IzlenmeSayisi,BegeniSayisi,BolumSayisi,BolumSuresi,IMDB_Puan,AktifMi,AnimeninKonusu,AnimeTanitimFoto,AnimeKucukFoto,FragmanVideosu")] Anime anime)
        {
            if (id != anime.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimeExists(anime.Id))
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
            ViewData["StudyoId"] = new SelectList(_context.Studyo, "Id", "Id", anime.StudyoId);
            return View(anime);
        }

        // GET: Anime/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime = await _context.Anime
                .Include(a => a.Studyo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        // POST: Anime/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anime = await _context.Anime.FindAsync(id);
            _context.Anime.Remove(anime);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimeExists(int id)
        {
            return _context.Anime.Any(e => e.Id == id);
        }
    }
}
