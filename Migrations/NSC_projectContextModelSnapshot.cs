﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NSC_project.Data;

#nullable disable

namespace NSCproject.Migrations
{
    [DbContext(typeof(NSC_projectContext))]
    partial class NSCprojectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NSC_project.Models.Auditorium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Seats_no")
                        .HasColumnType("int");

                    b.Property<int>("TheaterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TheaterId");

                    b.ToTable("Auditorium");
                });

            modelBuilder.Entity("NSC_project.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Actor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration_min")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Opening_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("NSC_project.Models.ReservedSeat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ReservetionId")
                        .HasColumnType("int");

                    b.Property<int>("ScreeningId")
                        .HasColumnType("int");

                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservetionId");

                    b.HasIndex("ScreeningId");

                    b.HasIndex("SeatId");

                    b.ToTable("ReservedSeat");
                });

            modelBuilder.Entity("NSC_project.Models.Reservetion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ScreeningId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ScreeningId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservetion");
                });

            modelBuilder.Entity("NSC_project.Models.Screening", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuditoriumId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("TheaterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AuditoriumId");

                    b.HasIndex("MovieId");

                    b.HasIndex("TheaterId");

                    b.ToTable("Screening");
                });

            modelBuilder.Entity("NSC_project.Models.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuditoriumId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuditoriumId");

                    b.ToTable("Seat");
                });

            modelBuilder.Entity("NSC_project.Models.Theater", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TheaterAddressId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TheaterAddressId");

                    b.ToTable("Theater");
                });

            modelBuilder.Entity("NSC_project.Models.TheaterAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TheaterAddress");
                });

            modelBuilder.Entity("NSC_project.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("NSC_project.Models.Auditorium", b =>
                {
                    b.HasOne("NSC_project.Models.Theater", "Theater")
                        .WithMany("Auditoriums")
                        .HasForeignKey("TheaterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Theater");
                });

            modelBuilder.Entity("NSC_project.Models.ReservedSeat", b =>
                {
                    b.HasOne("NSC_project.Models.Reservetion", "Reservetion")
                        .WithMany("ReservedSeats")
                        .HasForeignKey("ReservetionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NSC_project.Models.Screening", "Screening")
                        .WithMany("ReservedSeats")
                        .HasForeignKey("ScreeningId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NSC_project.Models.Seat", "Seat")
                        .WithMany("ReservedSeats")
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservetion");

                    b.Navigation("Screening");

                    b.Navigation("Seat");
                });

            modelBuilder.Entity("NSC_project.Models.Reservetion", b =>
                {
                    b.HasOne("NSC_project.Models.Screening", "Screening")
                        .WithMany("Reservetions")
                        .HasForeignKey("ScreeningId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NSC_project.Models.User", "User")
                        .WithMany("Reservetions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Screening");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NSC_project.Models.Screening", b =>
                {
                    b.HasOne("NSC_project.Models.Auditorium", "Auditorium")
                        .WithMany("Screenings")
                        .HasForeignKey("AuditoriumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NSC_project.Models.Movie", "Movie")
                        .WithMany("Screenings")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NSC_project.Models.Theater", "Theater")
                        .WithMany("Screenings")
                        .HasForeignKey("TheaterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auditorium");

                    b.Navigation("Movie");

                    b.Navigation("Theater");
                });

            modelBuilder.Entity("NSC_project.Models.Seat", b =>
                {
                    b.HasOne("NSC_project.Models.Auditorium", "Auditorium")
                        .WithMany("Seats")
                        .HasForeignKey("AuditoriumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auditorium");
                });

            modelBuilder.Entity("NSC_project.Models.Theater", b =>
                {
                    b.HasOne("NSC_project.Models.TheaterAddress", "TheaterAddress")
                        .WithMany("Theaters")
                        .HasForeignKey("TheaterAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TheaterAddress");
                });

            modelBuilder.Entity("NSC_project.Models.Auditorium", b =>
                {
                    b.Navigation("Screenings");

                    b.Navigation("Seats");
                });

            modelBuilder.Entity("NSC_project.Models.Movie", b =>
                {
                    b.Navigation("Screenings");
                });

            modelBuilder.Entity("NSC_project.Models.Reservetion", b =>
                {
                    b.Navigation("ReservedSeats");
                });

            modelBuilder.Entity("NSC_project.Models.Screening", b =>
                {
                    b.Navigation("ReservedSeats");

                    b.Navigation("Reservetions");
                });

            modelBuilder.Entity("NSC_project.Models.Seat", b =>
                {
                    b.Navigation("ReservedSeats");
                });

            modelBuilder.Entity("NSC_project.Models.Theater", b =>
                {
                    b.Navigation("Auditoriums");

                    b.Navigation("Screenings");
                });

            modelBuilder.Entity("NSC_project.Models.TheaterAddress", b =>
                {
                    b.Navigation("Theaters");
                });

            modelBuilder.Entity("NSC_project.Models.User", b =>
                {
                    b.Navigation("Reservetions");
                });
#pragma warning restore 612, 618
        }
    }
}
