﻿// <auto-generated />
using Ignis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ignis.Migrations.Ignis
{
    [DbContext(typeof(IgnisContext))]
    partial class IgnisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("Ignis.Models.RoleWorker", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Level");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("ID");

                    b.ToTable("RoleWorker");
                });
#pragma warning restore 612, 618
        }
    }
}