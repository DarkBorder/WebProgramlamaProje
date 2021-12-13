using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeBox.Models
{
    public class Bolum
    {
        public int Id { get; set; }

        public int? AnimeId { get; set; }
        [ForeignKey("AnimeId")]
        public Anime Anime { get; set; }

        public string BolumAdi { get; set; }

        public double? KacinciBolum { get; set; } // bazen 7.5 bolum seklinde bolumler olabiliyor

        /*[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}",ApplyFormatInEditMode =true)]*/
    }
}
