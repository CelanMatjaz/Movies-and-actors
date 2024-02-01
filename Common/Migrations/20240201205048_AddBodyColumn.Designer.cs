﻿// <auto-generated />
using System;
using CommonData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Common.Migrations
{
    [DbContext(typeof(RequestEntryDbContext))]
    [Migration("20240201205048_AddBodyColumn")]
    partial class AddBodyColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CommonData.RequestCountEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .HasColumnType("text")
                        .HasColumnName("body");

                    b.Property<string>("Endpoint")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("endpoint");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("method");

                    b.Property<string>("QueryParams")
                        .HasColumnType("text")
                        .HasColumnName("query_params");

                    b.Property<string>("Service")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("service");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("timestamp");

                    b.HasKey("Id");

                    b.ToTable("request_entries");
                });
#pragma warning restore 612, 618
        }
    }
}