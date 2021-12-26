using AnimeBox.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeBox.Controllers
{
    public class MarketController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IStringLocalizer<HomeController> _localizer;


        public MarketController(IStringLocalizer<HomeController> localizer, ApplicationDbContext context)
        {
            _context = context;
            _localizer = localizer;
        }


        public ActionResult Index()
        {

            var animeBilgileri = (from g in _context.Anime
                                join f in _context.AnimeKategori on g.Id equals f.AnimeId
                                join k in _context.Studyo on g.StudyoId equals k.Id                             
                                select new MarketDTO
                                {
                                    AnimeID = g.Id,
                                    Ad = g.AnimeAdi,
                                    Baslamatarihi = g.BaslamaTarihi,
                                    Bitistarihi = g.BitisTarihi,
                                    Begeni = g.BegeniSayisi,                                  
                                    Bolumsayisi = g.BolumSayisi,
                                    Tamamlananbolumsayisi = g.KacBolumTamamlandi,
                                    Izlenme = g.IzlenmeSayisi,
                                    SatinAlim = g.SatinAlimSayisi,
                                    PiyasaDegeri = g.Fiyat,
                                    Kucukfoto = g.AnimeKucukFoto,                                  
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

            return View(animeBilgileri);
        }


        public class MarketDTO
        {

            public int AnimeID { get; internal set; }

            public string Ad { get; internal set; }

            [DataType(DataType.Date)]
            public DateTime? Baslamatarihi { get; internal set; }

            [DataType(DataType.Date)]
            public DateTime? Bitistarihi { get; internal set; }

            public int? Begeni { get; internal set; }       

            public string Bolumsayisi { get; internal set; }

            public string Tamamlananbolumsayisi { get; internal set; }

            public int? Izlenme { get; internal set; }

            public int? SatinAlim { get; internal set; }

            public double? PiyasaDegeri { get; internal set; }

            public string Kucukfoto { get; internal set; }     

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


}
