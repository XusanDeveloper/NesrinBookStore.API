// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NesrinBookStore.Data.Contexts;

#nullable disable

namespace NesrinBookStore.Data.Migrations
{
    [DbContext(typeof(NesrinDbContext))]
    [Migration("20221028182414_Clean")]
    partial class Clean
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NesrinBooks.API.DataAccess.Entities.Books", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rating")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Author = "Kel Nyuport",
                            Description = "Tavsiya etiladi.",
                            Name = "Diqqat",
                            Price = "40 000",
                            Rating = "4"
                        },
                        new
                        {
                            Id = new Guid("f50fb0cb-cfe7-4649-af66-8178ad69230a"),
                            Author = "Kel Nyuport",
                            Description = "Tavsiya etiladi.",
                            Name = "Diqqat",
                            Price = "40 000",
                            Rating = "4"
                        },
                        new
                        {
                            Id = new Guid("4fdb4eec-1015-41a2-aab2-cf765fedb868"),
                            Author = "Kel Nyuport",
                            Description = "Tavsiya etiladi.",
                            Name = "Diqqat",
                            Price = "40 000",
                            Rating = "4"
                        },
                        new
                        {
                            Id = new Guid("9126aea5-cfa3-4e45-92da-be5ca57d3afe"),
                            Author = "Kel Nyuport",
                            Description = "Tavsiya etiladi.",
                            Name = "Diqqat",
                            Price = "40 000",
                            Rating = "4"
                        },
                        new
                        {
                            Id = new Guid("71da79e2-fecd-4e4b-bdca-40e7d6b1f421"),
                            Author = "Kel Nyuport",
                            Description = "Tavsiya etiladi.",
                            Name = "Diqqat",
                            Price = "40 000",
                            Rating = "4"
                        },
                        new
                        {
                            Id = new Guid("7178347d-1cc5-4b67-80e2-13e27f295c7a"),
                            Author = "Kel Nyuport",
                            Description = "Tavsiya etiladi.",
                            Name = "Diqqat",
                            Price = "40 000",
                            Rating = "4"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
