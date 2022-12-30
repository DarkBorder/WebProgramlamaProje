﻿// <auto-generated />
using System;
using AnimeBox.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnimeBox.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211215001418_begenisayisieklendi")]
    partial class begenisayisieklendi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AnimeBox.Models.Anime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<string>("AnimeAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnimeKucukFoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnimeTanitimFoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnimeninKonusu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BaslamaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("BegeniSayisi")
                        .HasColumnType("int");

                    b.Property<DateTime>("BitisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("BolumSayisi")
                        .HasColumnType("int");

                    b.Property<double?>("BolumSuresi")
                        .HasColumnType("float");

                    b.Property<double?>("Fiyat")
                        .HasColumnType("float");

                    b.Property<string>("FragmanVideosu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HangiSezondaCikti")
                        .HasColumnType("int");

                    b.Property<double?>("IMDB_Puan")
                        .HasColumnType("float");

                    b.Property<int?>("IzlenmeSayisi")
                        .HasColumnType("int");

                    b.Property<int?>("KacBolumTamamlandi")
                        .HasColumnType("int");

                    b.Property<int?>("SatinAlimSayisi")
                        .HasColumnType("int");

                    b.Property<int?>("StudyoId")
                        .HasColumnType("int");

                    b.Property<int?>("YasSiniri")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudyoId");

                    b.ToTable("Anime");
                });

            modelBuilder.Entity("AnimeBox.Models.AnimeKategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AnimeId")
                        .HasColumnType("int");

                    b.Property<int?>("KategoriId")
                        .HasColumnType("int");

                    b.Property<int?>("OnemSirasi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimeId");

                    b.HasIndex("KategoriId");

                    b.ToTable("AnimeKategori");
                });

            modelBuilder.Entity("AnimeBox.Models.AnimeYapimci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AnimeId")
                        .HasColumnType("int");

                    b.Property<int?>("YapimciId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimeId");

                    b.HasIndex("YapimciId");

                    b.ToTable("AnimeYapimci");
                });

            modelBuilder.Entity("AnimeBox.Models.Bolum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AnimeId")
                        .HasColumnType("int");

                    b.Property<string>("BolumAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("KacinciBolum")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AnimeId");

                    b.ToTable("Bolum");
                });

            modelBuilder.Entity("AnimeBox.Models.Hesap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("KutuphaneId")
                        .HasColumnType("int");

                    b.Property<int?>("SepetId")
                        .HasColumnType("int");

                    b.Property<string>("SoyAd")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KutuphaneId");

                    b.HasIndex("SepetId");

                    b.ToTable("Hesap");
                });

            modelBuilder.Entity("AnimeBox.Models.Kategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnimeTuru")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kategori");
                });

            modelBuilder.Entity("AnimeBox.Models.Kutuphane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnimeAd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnimeFoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HesapId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HesapId");

                    b.ToTable("Kutuphane");
                });

            modelBuilder.Entity("AnimeBox.Models.Sepet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AnimeId")
                        .HasColumnType("int");

                    b.Property<double?>("Fiyat")
                        .HasColumnType("float");

                    b.Property<int?>("HesapId")
                        .HasColumnType("int");

                    b.Property<double?>("Indirim")
                        .HasColumnType("float");

                    b.Property<bool?>("SiparisOk")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AnimeId");

                    b.HasIndex("HesapId");

                    b.ToTable("Sepet");
                });

            modelBuilder.Entity("AnimeBox.Models.Studyo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StudyoAdi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Studyo");
                });

            modelBuilder.Entity("AnimeBox.Models.Yapimci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("YapimciFirmaAdi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Yapimci");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AnimeBox.Models.Anime", b =>
                {
                    b.HasOne("AnimeBox.Models.Studyo", "Studyo")
                        .WithMany()
                        .HasForeignKey("StudyoId");
                });

            modelBuilder.Entity("AnimeBox.Models.AnimeKategori", b =>
                {
                    b.HasOne("AnimeBox.Models.Anime", "Anime")
                        .WithMany()
                        .HasForeignKey("AnimeId");

                    b.HasOne("AnimeBox.Models.Kategori", "Kategori")
                        .WithMany()
                        .HasForeignKey("KategoriId");
                });

            modelBuilder.Entity("AnimeBox.Models.AnimeYapimci", b =>
                {
                    b.HasOne("AnimeBox.Models.Studyo", "Anime")
                        .WithMany()
                        .HasForeignKey("AnimeId");

                    b.HasOne("AnimeBox.Models.Studyo", "Yapimci")
                        .WithMany()
                        .HasForeignKey("YapimciId");
                });

            modelBuilder.Entity("AnimeBox.Models.Bolum", b =>
                {
                    b.HasOne("AnimeBox.Models.Anime", "Anime")
                        .WithMany()
                        .HasForeignKey("AnimeId");
                });

            modelBuilder.Entity("AnimeBox.Models.Hesap", b =>
                {
                    b.HasOne("AnimeBox.Models.Hesap", "Kutuphane")
                        .WithMany()
                        .HasForeignKey("KutuphaneId");

                    b.HasOne("AnimeBox.Models.Hesap", "Sepet")
                        .WithMany()
                        .HasForeignKey("SepetId");
                });

            modelBuilder.Entity("AnimeBox.Models.Kutuphane", b =>
                {
                    b.HasOne("AnimeBox.Models.Hesap", "Hesap")
                        .WithMany()
                        .HasForeignKey("HesapId");
                });

            modelBuilder.Entity("AnimeBox.Models.Sepet", b =>
                {
                    b.HasOne("AnimeBox.Models.Anime", "Anime")
                        .WithMany()
                        .HasForeignKey("AnimeId");

                    b.HasOne("AnimeBox.Models.Hesap", "Hesap")
                        .WithMany()
                        .HasForeignKey("HesapId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
