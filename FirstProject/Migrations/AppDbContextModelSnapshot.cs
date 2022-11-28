﻿// <auto-generated />


using FirstProject.Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FirstProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FirstProject.Entities.Ogrenci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("OgrenciAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OgrenciNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OgrenciSoyadi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SinifId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SinifId");

                    b.ToTable("Ogrenciler");
                });

            modelBuilder.Entity("FirstProject.Entities.Sinif", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("SinifAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Siniflar");
                });

            modelBuilder.Entity("FirstProject.Entities.Ogrenci", b =>
                {
                    b.HasOne("FirstProject.Entities.Sinif", "sinif")
                        .WithMany("Ogrenciler")
                        .HasForeignKey("SinifId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("sinif");
                });

            modelBuilder.Entity("FirstProject.Entities.Sinif", b =>
                {
                    b.Navigation("Ogrenciler");
                });
#pragma warning restore 612, 618
        }
    }
}
