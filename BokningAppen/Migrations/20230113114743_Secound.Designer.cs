﻿// <auto-generated />
using System;
using BokningsAppen1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BokningsAppen1.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230113114743_Secound")]
    partial class Secound
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BokningsAppen1.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DayofWeek")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Empty")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.Property<int?>("WeekNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BokningsAppen1.Models.ConferenceRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Detalil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberOfSitis")
                        .HasColumnType("int");

                    b.Property<int?>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("BokningsAppen1.Models.Booking", b =>
                {
                    b.HasOne("BokningsAppen1.Models.ConferenceRoom", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("BokningsAppen1.Models.ConferenceRoom", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
