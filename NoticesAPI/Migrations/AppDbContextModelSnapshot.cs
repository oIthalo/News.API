﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NoticesAPI.Data;

#nullable disable

namespace NoticesAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("News.API.Models.NewsItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "author");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "content");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "description");

                    b.Property<DateTime>("PublishedAt")
                        .HasColumnType("datetime(6)")
                        .HasAnnotation("Relational:JsonPropertyName", "publishedAt");

                    b.Property<string>("SourceId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "title");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "url");

                    b.Property<string>("UrlToImage")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "urlToImage");

                    b.HasKey("Id");

                    b.HasIndex("SourceId");

                    b.ToTable("NewsItems");
                });

            modelBuilder.Entity("News.API.Models.Source", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.HasKey("Id");

                    b.ToTable("Source");

                    b.HasAnnotation("Relational:JsonPropertyName", "source");
                });

            modelBuilder.Entity("NoticesAPI.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("NoticesAPI.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("News.API.Models.NewsItem", b =>
                {
                    b.HasOne("News.API.Models.Source", "Source")
                        .WithMany()
                        .HasForeignKey("SourceId");

                    b.Navigation("Source");
                });
#pragma warning restore 612, 618
        }
    }
}
