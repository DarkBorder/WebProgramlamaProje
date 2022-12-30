using AnimeBox.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeBox.Data
{
    public class ApplicationDbContext : IdentityDbContext <Musteri>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Anime> Anime { get; set; }

        public DbSet<Yapimci> Yapimci { get; set; }

        public DbSet<Kategori> Kategori { get; set; }

        public DbSet<Studyo> Studyo { get; set; }

        public DbSet<Bolum> Bolum { get; set; }

        public DbSet<Sepet> Sepet { get; set; }

        public DbSet<AnimeYapimci> AnimeYapimci { get; set; }

        public DbSet<AnimeKategori> AnimeKategori { get; set; }

        public DbSet<Kutuphane> Kutuphane { get; set; }
    }
}
