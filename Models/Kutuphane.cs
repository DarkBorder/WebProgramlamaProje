using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeBox.Models
{
    public class Kutuphane
    {
        public int Id { get; set; }

        public int? HesapId { get; set; }
        [ForeignKey("HesapId")]
        public Hesap Hesap { get; set; }
    }
}
