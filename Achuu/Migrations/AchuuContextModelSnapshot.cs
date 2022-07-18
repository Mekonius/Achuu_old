﻿// <auto-generated />
using System;
using Achuu.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Achuu.Migrations
{
    [DbContext(typeof(AchuuContext))]
    partial class AchuuContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("Achuu.Data.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAllergic")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProductID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductID");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Achuu.Data.Locker", b =>
                {
                    b.Property<int>("LockerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("LockerID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Lockers");
                });

            modelBuilder.Entity("Achuu.Data.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("GalleryID")
                        .HasColumnType("TEXT");

                    b.Property<int?>("LockerID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Warning")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductID");

                    b.HasIndex("LockerID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Achuu.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Hash")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Salt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Token")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("TokenExpiration")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Achuu.Data.Ingredient", b =>
                {
                    b.HasOne("Achuu.Data.Product", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("ProductID");
                });

            modelBuilder.Entity("Achuu.Data.Locker", b =>
                {
                    b.HasOne("Achuu.Data.User", null)
                        .WithOne("Locker")
                        .HasForeignKey("Achuu.Data.Locker", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Achuu.Data.Product", b =>
                {
                    b.HasOne("Achuu.Data.Locker", null)
                        .WithMany("Products")
                        .HasForeignKey("LockerID");
                });

            modelBuilder.Entity("Achuu.Data.Locker", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Achuu.Data.Product", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("Achuu.Data.User", b =>
                {
                    b.Navigation("Locker");
                });
#pragma warning restore 612, 618
        }
    }
}
