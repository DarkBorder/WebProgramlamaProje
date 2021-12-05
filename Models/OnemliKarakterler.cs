using AnimeBox.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeBox.Models
{
    public class OnemliKarakterler
    {
        public int Id { get; set; }

        public int? AnimeId { get; set; }
        [ForeignKey("AnimeId")]
        public Anime Anime { get; set; }

        public string KarakterinAdi { get; set; }

        public int? OnemSirasi { get; set; }

       
       
        

    }
}
