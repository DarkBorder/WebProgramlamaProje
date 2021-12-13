using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeBox.Models
{
    public class AnimeYapimci
    {
        public int Id { get; set; }

        public int? AnimeId { get; set; }
        [ForeignKey("AnimeId")]
        public Studyo Anime { get; set; }

        public int? YapimciId { get; set; }
        [ForeignKey("YapimciId")]
        public Studyo Yapimci { get; set; }

    }
}
