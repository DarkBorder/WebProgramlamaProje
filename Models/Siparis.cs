using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeBox.Models
{
    public class Siparis
    {
        public int Id { get; set; }

        public int? AnimeId { get; set; }
        [ForeignKey("AnimeId")]
        public Anime Anime { get; set; }

        //kullanici id gelicek


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SatinAlimTarihi { get; set; }

        public double OdenenUcret { get; set; }

        public string SiparisKodu { get; set; }


    }
}
