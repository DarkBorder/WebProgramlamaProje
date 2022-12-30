using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeBox.Models
{
    public class Musteri : IdentityUser
    {

        public string Ad { get; set; }

        public string Soyad { get; set; }

        [DataType(DataType.Date)]
        public DateTime DogumTarihi { get; set; }

        public string Yetki { get; set; }

    }
}
