﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cwiczenia.API.Data;

namespace cwiczenia.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191014195449_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("cwiczenia.API.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("cwiczenia.API.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GradeName");

                    b.Property<string>("Section");

                    b.HasKey("Id");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("cwiczenia.API.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<int?>("GradeId");

                    b.Property<decimal>("Height");

                    b.Property<string>("Name");

                    b.Property<string>("Photo");

                    b.Property<string>("Surname");

                    b.Property<float>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("cwiczenia.API.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<byte[]>("Photo");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("cwiczenia.API.Models.Class", b =>
                {
                    b.HasOne("cwiczenia.API.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("cwiczenia.API.Models.Student", b =>
                {
                    b.HasOne("cwiczenia.API.Models.Grade")
                        .WithMany("Students")
                        .HasForeignKey("GradeId");
                });
#pragma warning restore 612, 618
        }
    }
}
