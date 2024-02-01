﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesService;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Movies.Migrations
{
    [DbContext(typeof(MoviesDbContext))]
    [Migration("20240201194926_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MoviesService.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image_link");

                    b.Property<string>("ListOfActors")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("list_of_actors");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<short>("Year")
                        .HasColumnType("smallint")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.ToTable("movies");

                    b.HasData(
                        new
                        {
                            Id = 10001,
                            Description = "A reclusive author who writes espionage novels about a secret agent...",
                            ImageLink = "https://m.media-amazon.com/images/M/MV5BZDM3YTg4MGUtZmUxNi00YmEyLTllNTctNjYyNjZlZGViNmFhXkEyXkFqcGdeQXVyMTUzMTg2ODkz._V1_UX140_CR0,0,140,209_AL_.jpg",
                            ListOfActors = "Actor 1, Actor 2, Actor 3",
                            Title = "Argylle",
                            Year = (short)2024
                        },
                        new
                        {
                            Id = 10002,
                            Description = "Two strangers land jobs with a spy agency that offers them a life of espionage, wealth, and travel. The catch: new identities in an arranged marriage.",
                            ImageLink = "https://m.media-amazon.com/images/M/MV5BMDE0M2YyM2UtODRmNC00YjAyLWIwMjktOTAwMDBiYjBhMGZmXkEyXkFqcGdeQXVyMjkwOTAyMDU@._V1_UY209_CR0,0,140,209_AL_.jpg",
                            ListOfActors = "Actor 1, Actor 2, Actor 3",
                            Title = "Mr. & Mrs. Smith",
                            Year = (short)2024
                        });
                });
#pragma warning restore 612, 618
        }
    }
}