﻿// <auto-generated />
using System;
using LibroHub.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibroHub.Infrastructure.Migrations
{
    [DbContext(typeof(LibroHubDbContext))]
    [Migration("20240105164030_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibroHub.Domain.Entities.LibroHub", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EncodedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LibroHub");
                });

            modelBuilder.Entity("LibroHub.Domain.Entities.LibroHub", b =>
                {
                    b.OwnsOne("LibroHub.Domain.Entities.LibroHubDetails", "BookDetails", b1 =>
                        {
                            b1.Property<int>("LibroHubId")
                                .HasColumnType("int");

                            b1.Property<string>("Author")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("BookCategory")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int?>("PageNumber")
                                .HasColumnType("int");

                            b1.Property<int?>("Rating")
                                .HasColumnType("int");

                            b1.HasKey("LibroHubId");

                            b1.ToTable("LibroHub");

                            b1.WithOwner()
                                .HasForeignKey("LibroHubId");
                        });

                    b.Navigation("BookDetails")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
