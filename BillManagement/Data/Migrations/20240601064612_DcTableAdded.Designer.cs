﻿// <auto-generated />
using System;
using BillManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BillManagement.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240601064612_DcTableAdded")]
    partial class DcTableAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.19");

            modelBuilder.Entity("BillManagement.Models.Dcproduct", b =>
                {
                    b.Property<int>("DcProductPk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("DcFk")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DcNo")
                        .HasColumnType("TEXT");

                    b.Property<string>("EwayBillNo")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductFk")
                        .HasColumnType("INTEGER");

                    b.HasKey("DcProductPk");

                    b.HasIndex("DcFk");

                    b.HasIndex("ProductFk");

                    b.ToTable("Dcproducts");
                });

            modelBuilder.Entity("BillManagement.Models.Dctable", b =>
                {
                    b.Property<int>("DcPk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("DcNo")
                        .HasColumnType("TEXT");

                    b.Property<string>("EwayBillNo")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("InvoiceCheck")
                        .HasColumnType("INTEGER");

                    b.HasKey("DcPk");

                    b.ToTable("Dctables");
                });

            modelBuilder.Entity("BillManagement.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("HSN")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PONumber")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BillManagement.Models.Dcproduct", b =>
                {
                    b.HasOne("BillManagement.Models.Dctable", "DcFkNavigation")
                        .WithMany("Dcproducts")
                        .HasForeignKey("DcFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BillManagement.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DcFkNavigation");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BillManagement.Models.Dctable", b =>
                {
                    b.Navigation("Dcproducts");
                });
#pragma warning restore 612, 618
        }
    }
}