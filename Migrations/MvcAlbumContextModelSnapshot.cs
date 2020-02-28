﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using moment3.Data;

namespace moment3.Migrations
{
    [DbContext(typeof(MvcAlbumContext))]
    partial class MvcAlbumContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("moment3.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AmountOfSongs")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ArtistId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("PlayTime")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("AlbumId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("moment3.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.HasKey("ArtistId");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("moment3.Models.Album", b =>
                {
                    b.HasOne("moment3.Models.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId");
                });
#pragma warning restore 612, 618
        }
    }
}
