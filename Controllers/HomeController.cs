using AnimeBox.Data;
using AnimeBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeBox.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            /* var animeler = _context.Anime
                 .Include(f => f.Studyo);

             return View(animeler.ToList()); */

            var animeListesi = (from g in _context.Anime
                                join f in _context.AnimeKategori on g.Id equals f.AnimeId
                                select new AnimeDTO
                                {
                                    AnimeID = g.Id,
                                    Ad = g.AnimeAdi,
                                    Baslamatarihi = g.BaslamaTarihi,
                                    Bitistarihi = g.BitisTarihi,
                                    Begeni = g.BegeniSayisi,
                                    SezonNO = g.PartNo,
                                    PartNO = g.SezonNo,
                                    Bolumsayisi = g.BolumSayisi,
                                    Tamamlananbolumsayisi = g.KacBolumTamamlandi,
                                    Izlenme = g.IzlenmeSayisi,
                                    SatinAlim = g.SatinAlimSayisi,
                                    PiyasaDegeri = g.Fiyat,
                                    Kucukfoto = g.AnimeKucukFoto,
                                    Tanitimfoto = g.AnimeTanitimFoto,
                                    Aktiflik = g.AktifMi,
                                    Kategoriadi = f.Kategori.AnimeTuru,
                                    Onemsirasi = f.OnemSirasi
                                })
                                .ToList();
            
            return View(animeListesi);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

     public class AnimeDTO {

         public int AnimeID { get; internal set; }

         public string Ad { get; internal set; }

        [DataType(DataType.Date)]
        public DateTime? Baslamatarihi { get; internal set; }

        [DataType(DataType.Date)]
        public DateTime? Bitistarihi { get; internal set; }

        public int? Begeni { get; internal set; }

        public int? SezonNO { get; internal set; }

        public int? PartNO { get; internal set; }

        public string Bolumsayisi { get; internal set; }

        public string Tamamlananbolumsayisi { get; internal set; }

        public int? Izlenme { get; internal set; }

         public int? SatinAlim { get; internal set; }

         public double? PiyasaDegeri { get; internal set; }

         public string Kucukfoto { get; internal set; }

         public string Tanitimfoto { get; internal set; }

         public bool? Aktiflik { get; internal set; }

         public string Kategoriadi { get; internal set; }

        public int? Onemsirasi { get; internal set; }

     }
}
