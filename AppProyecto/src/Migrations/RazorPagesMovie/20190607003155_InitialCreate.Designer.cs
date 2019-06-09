﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Migrations.RazorPagesMovie
{
    [DbContext(typeof(RazorPagesMovieContext))]
    [Migration("20190607003155_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("RazorPagesMovie.Areas.Identity.Data.Tecnico", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<bool>("Available");

                    b.Property<int>("AverageRanking");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<DateTime>("DOB");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Role");

                    b.Property<int?>("RoleID");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("TotalWorks");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.Property<int>("WorkedHours");

                    b.HasKey("Id");

                    b.ToTable("Worker");
                });

            modelBuilder.Entity("RazorPagesMovie.Models.WorkerRole", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Level");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Role");
                });
#pragma warning restore 612, 618
        }
    }
}