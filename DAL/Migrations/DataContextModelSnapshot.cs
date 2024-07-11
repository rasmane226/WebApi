﻿// <auto-generated />
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Entities.Bolumler", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Aktif")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Bolumlers");
                });

            modelBuilder.Entity("DAL.Entities.Depocikisi", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Aciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Adet")
                        .HasColumnType("int");

                    b.Property<string>("Marka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeriNo")
                        .HasColumnType("int");

                    b.Property<int>("TeslimTarihi")
                        .HasColumnType("int");

                    b.Property<string>("VerilenBirimi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VerilenPersonel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Depocikisis");
                });

            modelBuilder.Entity("DAL.Entities.Depogirisi", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Aciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Adet")
                        .HasColumnType("int");

                    b.Property<int>("AlimTarihi")
                        .HasColumnType("int");

                    b.Property<int>("GirisTarihi")
                        .HasColumnType("int");

                    b.Property<string>("Marka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeriNo")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Depogirisis");
                });

            modelBuilder.Entity("DAL.Entities.Markalar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Aktif")
                        .HasColumnType("bit");

                    b.Property<int>("UrunlerId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UrunlerId");

                    b.ToTable("Markalars");
                });

            modelBuilder.Entity("DAL.Entities.Modeller", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Adet")
                        .HasColumnType("int");

                    b.Property<bool>("Aktif")
                        .HasColumnType("bit");

                    b.Property<int>("MarkalarId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MarkalarId");

                    b.ToTable("Modellers");
                });

            modelBuilder.Entity("DAL.Entities.Urunler", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Aktif")
                        .HasColumnType("bit");

                    b.Property<int>("BolumlerId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BolumlerId");

                    b.ToTable("Urunlers");
                });

            modelBuilder.Entity("DAL.Entities.Markalar", b =>
                {
                    b.HasOne("DAL.Entities.Urunler", "Urunler")
                        .WithMany("Markalars")
                        .HasForeignKey("UrunlerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Urunler");
                });

            modelBuilder.Entity("DAL.Entities.Modeller", b =>
                {
                    b.HasOne("DAL.Entities.Markalar", "Markalar")
                        .WithMany("Modellers")
                        .HasForeignKey("MarkalarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Markalar");
                });

            modelBuilder.Entity("DAL.Entities.Urunler", b =>
                {
                    b.HasOne("DAL.Entities.Bolumler", "Bolumler")
                        .WithMany("Urunlers")
                        .HasForeignKey("BolumlerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bolumler");
                });

            modelBuilder.Entity("DAL.Entities.Bolumler", b =>
                {
                    b.Navigation("Urunlers");
                });

            modelBuilder.Entity("DAL.Entities.Markalar", b =>
                {
                    b.Navigation("Modellers");
                });

            modelBuilder.Entity("DAL.Entities.Urunler", b =>
                {
                    b.Navigation("Markalars");
                });
#pragma warning restore 612, 618
        }
    }
}
