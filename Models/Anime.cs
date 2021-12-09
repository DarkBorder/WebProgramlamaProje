using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeBox.Models
{
    public class Anime
    {
        public int Id { get; set; }

        public int? StudyoId { get; set; }
        [ForeignKey("StudyoId")]
        public Studyo Studyo { get; set; }

        public string AnimeAdi { get; set; }

        public int? YapimYili { get; set; }

        public int? KacinciSezon { get; set; }

        public Sezon? HangiSezondaCikti { get; set; }

        public double? Fiyat { get; set; }

        public int? BolumSayisi { get; set; }

        public double? BolumUzunlugu { get; set; }

        public double? IMDB_Puan { get; set; }

        public bool? AktifMi { get; set; }

        public DateTime CikisTarihi { get; set; }

        public string AnimeninKonusu { get; set; }

        public string AnimeTanitimFoto { get; set; }

        public string FragmanVideosu { get; set; }

      

    }

}
