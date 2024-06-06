﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestApplicationTessa.Models;

#nullable disable

namespace TestApplicationTessa.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("TestApplicationTessa.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ActiveTaskId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ActiveTaskId")
                        .IsUnique();

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("TestApplicationTessa.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DocumentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("PreviousTaskId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("PreviousTaskId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TestApplicationTessa.Models.Document", b =>
                {
                    b.HasOne("TestApplicationTessa.Models.Task", "ActiveTask")
                        .WithOne("ActiveTaskDocument")
                        .HasForeignKey("TestApplicationTessa.Models.Document", "ActiveTaskId");

                    b.Navigation("ActiveTask");
                });

            modelBuilder.Entity("TestApplicationTessa.Models.Task", b =>
                {
                    b.HasOne("TestApplicationTessa.Models.Document", "Document")
                        .WithMany("Tasks")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestApplicationTessa.Models.Task", "PreviousTask")
                        .WithMany()
                        .HasForeignKey("PreviousTaskId");

                    b.Navigation("Document");

                    b.Navigation("PreviousTask");
                });

            modelBuilder.Entity("TestApplicationTessa.Models.Document", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("TestApplicationTessa.Models.Task", b =>
                {
                    b.Navigation("ActiveTaskDocument");
                });
#pragma warning restore 612, 618
        }
    }
}
