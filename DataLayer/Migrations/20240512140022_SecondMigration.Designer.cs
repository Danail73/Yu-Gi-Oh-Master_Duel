﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(CardsDbContext))]
    [Migration("20240512140022_SecondMigration")]
    partial class SecondMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusinessLayer.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CardText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DeckId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DeckId");

                    b.ToTable("Cards");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Card");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("BusinessLayer.Deck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastEdited")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Decks");
                });

            modelBuilder.Entity("BusinessLayer.Monster", b =>
                {
                    b.HasBaseType("BusinessLayer.Card");

                    b.Property<long>("ATK")
                        .HasColumnType("bigint");

                    b.Property<string>("Attribute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("DEF")
                        .HasColumnType("bigint");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Typing")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Monster");
                });

            modelBuilder.Entity("BusinessLayer.Spell", b =>
                {
                    b.HasBaseType("BusinessLayer.Card");

                    b.Property<string>("Typing")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Cards", t =>
                        {
                            t.Property("Typing")
                                .HasColumnName("Spell_Typing");
                        });

                    b.HasDiscriminator().HasValue("Spell");
                });

            modelBuilder.Entity("BusinessLayer.Trap", b =>
                {
                    b.HasBaseType("BusinessLayer.Card");

                    b.Property<string>("Typing")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Cards", t =>
                        {
                            t.Property("Typing")
                                .HasColumnName("Trap_Typing");
                        });

                    b.HasDiscriminator().HasValue("Trap");
                });

            modelBuilder.Entity("BusinessLayer.Card", b =>
                {
                    b.HasOne("BusinessLayer.Deck", null)
                        .WithMany("Cards")
                        .HasForeignKey("DeckId");
                });

            modelBuilder.Entity("BusinessLayer.Deck", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}