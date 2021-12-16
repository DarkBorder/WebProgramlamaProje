using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [DataType(DataType.Date)]
        public DateTime? BaslamaTarihi { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BitisTarihi { get; set; }

        public string KacBolumTamamlandi { get; set; }

        public Sezon? HangiSezondaCikti { get; set; }

        public int? SezonNo { get; set; }

        public int? PartNo { get; set; }

        public double? Fiyat { get; set; }

        public int? YasSiniri { get; set; }

        public int? SatinAlimSayisi { get; set; }

        public int? IzlenmeSayisi { get; set; }

        public int? BegeniSayisi { get; set; }

        public string BolumSayisi { get; set; }

        public double? BolumSuresi { get; set; }

        public double? IMDB_Puan { get; set; }

        public bool? AktifMi { get; set; }
        public string AnimeninKonusu { get; set; }

        public string AnimeTanitimFoto { get; set; }

        public string AnimeKucukFoto { get; set; }

        public string FragmanVideosu { get; set; }

      

    }

}
