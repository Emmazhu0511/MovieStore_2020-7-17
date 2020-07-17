﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieStore.Infrastructure.Data;

namespace MovieStore.Infrastructure.Migrations
{
    [DbContext(typeof(MovieStoreDbContext))]
    [Migration("20200715151524_MovieCastTableRelation")]
    partial class MovieCastTableRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieStore.Core.Entities.Cast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(4096);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProfilePath")
                        .HasColumnType("nvarchar(2084)")
                        .HasMaxLength(2084);

                    b.Property<string>("TmdbUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(4096);

                    b.HasKey("Id");

                    b.ToTable("Cast");
                });

            modelBuilder.Entity("MovieStore.Core.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("MovieStore.Core.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BackdropUrl")
                        .HasColumnType("nvarchar(2084)")
                        .HasMaxLength(2084);

                    b.Property<decimal?>("Budget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("ImdbUrl")
                        .HasColumnType("nvarchar(2084)")
                        .HasMaxLength(2084);

                    b.Property<string>("OriginalLanguage")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("Overview")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(4096);

                    b.Property<string>("PosterUrl")
                        .HasColumnType("nvarchar(2084)")
                        .HasMaxLength(2084);

                    b.Property<decimal?>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(5, 2)")
                        .HasDefaultValue(9.9m);

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Revenue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("RunTime")
                        .HasColumnType("int");

                    b.Property<string>("Tagline")
                        .HasColumnType("nvarchar(512)")
                        .HasMaxLength(512);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("TmdbUrl")
                        .HasColumnType("nvarchar(2084)")
                        .HasMaxLength(2084);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("MovieStore.Core.Entities.MovieCast", b =>
                {
                    b.Property<int>("CastId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("Character")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.HasKey("CastId", "MovieId", "Character");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieCase");
                });

            modelBuilder.Entity("MovieStore.Core.Entities.MovieGenre", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("GenreId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieGenre");
                });

            modelBuilder.Entity("MovieStore.Core.Entities.Trailer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(2084)")
                        .HasMaxLength(2084);

                    b.Property<string>("TrailerUrl")
                        .HasColumnType("nvarchar(2084)")
                        .HasMaxLength(2084);

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Trailer");
                });

            modelBuilder.Entity("MovieStore.Core.Entities.MovieCast", b =>
                {
                    b.HasOne("MovieStore.Core.Entities.Cast", "Cast")
                        .WithMany("MovieCasts")
                        .HasForeignKey("CastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieStore.Core.Entities.Movie", "Movie")
                        .WithMany("MovieCasts")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieStore.Core.Entities.MovieGenre", b =>
                {
                    b.HasOne("MovieStore.Core.Entities.Genre", "Genre")
                        .WithMany("MovieGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieStore.Core.Entities.Movie", "Movie")
                        .WithMany("MovieGenres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieStore.Core.Entities.Trailer", b =>
                {
                    b.HasOne("MovieStore.Core.Entities.Movie", "Movie")
                        .WithMany("Trailers")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
