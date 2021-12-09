using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeBox.Models
{
    public class Sepet
    {
        public int Id { get; set; }

        //kullanici id gelicek
        public int? AnimeId { get; set; }
        [ForeignKey("AnimeId")]
        public Anime Anime { get; set; }

        public double Fiyat { get; set; }

        public double Indirim { get; set; }

        public bool? SiparisOk { get; set; } = false;
       
    }
}
