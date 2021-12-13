using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeBox.Models
{
    public class Hesap
    {
        public int Id { get; set; }

        public string Ad { get; set; }

        public string SoyAd { get; set; }

        [EmailAddress(ErrorMessage="{0} Geçersiz")]
        public string Email { get; set; }

        public DateTime KayitTarihi { get; set; }
    }
}
