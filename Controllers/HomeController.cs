using AnimeBox.Data;
using AnimeBox.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
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
        private readonly IStringLocalizer<HomeController> _localizer;


        public HomeController(IStringLocalizer<HomeController> localizer,  ApplicationDbContext context)
        {
            _context = context;
            _localizer = localizer;
        }

        public IActionResult AnimeDetay(string arama) {

            var animeListesi = (from g in _context.Anime
                                join f in _context.AnimeKategori on g.Id equals f.AnimeId 
                                join k in _context.Studyo on g.StudyoId equals k.Id
                                where g.AnimeAdi!.Contains(arama)
                                select new AnimeDTO
                                {
                                    AnimeID = g.Id,
                                    Ad = g.AnimeAdi,
                                    Baslamatarihi = g.BaslamaTarihi,
                                    Bitistarihi = g.BitisTarihi,
                                    Begeni = g.BegeniSayisi,
                                    SezonNO = g.SezonNo,
                                    PartNO = g.PartNo,
                                    Bolumsayisi = g.BolumSayisi,
                                    Tamamlananbolumsayisi = g.KacBolumTamamlandi,
                                    Izlenme = g.IzlenmeSayisi,
                                    SatinAlim = g.SatinAlimSayisi,
                                    PiyasaDegeri = g.Fiyat,
                                    Kucukfoto = g.AnimeKucukFoto,
                                    Tanitimfoto = g.AnimeTanitimFoto,
                                    Aktiflik = g.AktifMi,
                                    Konusu = g.AnimeninKonusu,
                                    Onemsirasi = f.OnemSirasi,
                                    Kategoriadi = f.Kategori.AnimeTuru,
                                    StudyoADI = k.StudyoAdi,
                                    YasSINIRI = g.YasSiniri,
                                    IMDB = g.IMDB_Puan,
                                    Sure = g.BolumSuresi
                                })
                               .ToList();
       
            return View(animeListesi);
        }

        public IActionResult Index()
        {             
              
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
                                    Konusu = g.AnimeninKonusu,
                                    Onemsirasi = f.OnemSirasi,
                                    Kategoriadi = f.Kategori.AnimeTuru,                              
                                })
                                .ToList();
            


            return View(animeListesi);

        }


        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            

            return Redirect(Request.Headers["Referer"].ToString());
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

        public string Konusu { get; internal set; }

        public string StudyoADI { get; internal set; }

        public int? YasSINIRI { get; internal set; }

        public double? IMDB { get; internal set; }

        public double? Sure { get; internal set; }

    }
}
