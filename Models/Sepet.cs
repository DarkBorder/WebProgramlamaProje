using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeBox.Models
{
    public class Sepet
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public int? AnimeId { get; set; }
        [ForeignKey("AnimeId")]
        public Anime Anime { get; set; }
        public DateTime? SepeteEklenmeTarihi { get; set; }

        public bool? SiparisOk { get; set; } = false;

      
      
    }
}
