using AnimeBox.Data;
using AnimeBox.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeBox.Controllers
{
    public class SepetController : Controller
    {


        private readonly ApplicationDbContext _context;
        private readonly IStringLocalizer<HomeController> _localizer;


        public SepetController(IStringLocalizer<HomeController> localizer, ApplicationDbContext context)
        {
            _context = context;
            _localizer = localizer;
        }


        public ActionResult Index()
        {
                      
            var tumSepet = (from g in _context.Anime                          
                                join f in _context.Sepet on g.Id equals f.AnimeId
                                select new AnimeDTO
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
                                    Eposta = f.Email,
                                    SepeteEklenmeTARIHI = f.SepeteEklenmeTarihi,
                                    SatinAlindiMi = f.SiparisOk,
                                    SepetID = f.Id

                                })
                                .OrderBy(x=>x.SepeteEklenmeTARIHI).ToList();

            var kullaniciSepeti = tumSepet.Where(x => x.Eposta == User.Identity.Name).ToList();

            return View(kullaniciSepeti);
        }


        public ActionResult SepeteAnimeEkle(int id)
        {
            var animeListesi = (from g in _context.Sepet
                              
                                where g.AnimeId == id && g.Email == User.Identity.Name
                                select new SepetDTO
                                {
                                   EPosta = g.Email,
                                   
                                })
                               .ToList();


            if (animeListesi.Count==0)
            {
                var sepet = new Sepet[] { new Sepet { Email = User.Identity.Name, AnimeId = id, SepeteEklenmeTarihi = DateTime.Now } };


                foreach (Sepet s in sepet)
                {
                    _context.Add(s);
                }


                _context.SaveChanges();

            }
           
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SepeteAnimeEkleMarket(int id)
        {
            var animeListesi = (from g in _context.Sepet

                                where g.AnimeId == id && g.Email == User.Identity.Name
                                select new SepetDTO
                                {
                                    EPosta = g.Email,

                                })
                               .ToList();


            if (animeListesi.Count == 0)
            {
                var sepet = new Sepet[] { new Sepet { Email = User.Identity.Name, AnimeId = id, SepeteEklenmeTarihi = DateTime.Now } };


                foreach (Sepet s in sepet)
                {
                    _context.Add(s);
                }


                _context.SaveChanges();

            }

            return RedirectToAction("Index", "Market");
        }


        public ActionResult SepeteAnimeEkleSlider(int id)
        {
            var animeListesi = (from g in _context.Sepet

                                where g.AnimeId == id && g.Email == User.Identity.Name
                                select new SepetDTO
                                {
                                    EPosta = g.Email,

                                })
                               .ToList();


            if (animeListesi.Count == 0)
            {
                var sepet = new Sepet[] { new Sepet { Email = User.Identity.Name, AnimeId = id, SepeteEklenmeTarihi = DateTime.Now } };


                foreach (Sepet s in sepet)
                {
                    _context.Add(s);
                }


                _context.SaveChanges();

            }

            return RedirectToAction("Index", "Sepet");
        }


        public ActionResult SepettenAnimeSil(int sepetId)
        {

            Sepet silinecekAnime = _context.Sepet.Find(sepetId);

            _context.Sepet.Remove(silinecekAnime);

            _context.SaveChanges();

            return RedirectToAction("Index", "Sepet");
        }


        public ActionResult SepettenTumAnimeleriSil()
        {

            List <Sepet> Urunler = (from g in _context.Sepet

                               where (g.Email == User.Identity.Name)
                               select g).ToList();



            foreach (Sepet urunler in Urunler)
            {
                _context.Sepet.Remove(urunler);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Sepet");
        }

        public class AnimeDTO
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
            public string Eposta { get; internal set; }

            public DateTime? SepeteEklenmeTARIHI { get; internal set; }

            public bool? SatinAlindiMi { get; internal set; }

            public int SepetID { get; internal set; }

        }




        public class SepetDTO
        {
            public string EPosta { get; internal set; }
        
        }
    }
}
