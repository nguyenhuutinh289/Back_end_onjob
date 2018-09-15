﻿// <auto-generated />
using System;
using Code.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Code.Migrations
{
    [DbContext(typeof(DemoContext))]
    partial class DemoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Code.Models.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("Code.Models.AuthorTitle", b =>
                {
                    b.Property<int>("AuthorID");

                    b.Property<int>("TitleID");

                    b.HasKey("AuthorID", "TitleID");

                    b.HasIndex("TitleID");

                    b.ToTable("AuthorTitle");
                });

            modelBuilder.Entity("Code.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Code.Models.CategoryTitle", b =>
                {
                    b.Property<int>("CategoryID");

                    b.Property<int>("TitleID");

                    b.HasKey("CategoryID", "TitleID");

                    b.HasIndex("TitleID");

                    b.ToTable("CategoryTitles");
                });

            modelBuilder.Entity("Code.Models.Language", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Code.Models.Librarian", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Gender");

                    b.Property<string>("Image");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasMaxLength(11);

                    b.Property<bool>("Status");

                    b.HasKey("ID");

                    b.ToTable("Librarian");
                });

            modelBuilder.Entity("Code.Models.Publisher", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Phone");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("Code.Models.Title", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Description");

                    b.Property<int>("Edition");

                    b.Property<string>("ISBN")
                        .HasColumnType("char(50)");

                    b.Property<string>("Image");

                    b.Property<int>("LanguageID");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int>("PublisherID");

                    b.Property<DateTime>("PublishingDate")
                        .HasColumnType("datetime");

                    b.Property<string>("TableOfContent");

                    b.HasKey("ID");

                    b.HasIndex("LanguageID");

                    b.HasIndex("PublisherID");

                    b.ToTable("Titles");
                });

            modelBuilder.Entity("Code.Models.AuthorTitle", b =>
                {
                    b.HasOne("Code.Models.Author", "Author")
                        .WithMany("AuthorTitles")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Code.Models.Title", "Title")
                        .WithMany("AuthorTitles")
                        .HasForeignKey("TitleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Code.Models.CategoryTitle", b =>
                {
                    b.HasOne("Code.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Code.Models.Title", "Title")
                        .WithMany("CategoryTitles")
                        .HasForeignKey("TitleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Code.Models.Title", b =>
                {
                    b.HasOne("Code.Models.Language", "Language")
                        .WithMany("Titles")
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Code.Models.Publisher", "Publisher")
                        .WithMany("Titles")
                        .HasForeignKey("PublisherID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}