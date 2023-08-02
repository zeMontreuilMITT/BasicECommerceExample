﻿// <auto-generated />
using System;
using BasicECommerceExample.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BasicECommerceExample.Migrations
{
    [DbContext(typeof(ECommerceContext))]
    [Migration("20230802150436_CustPrimarySecondaryAddresses")]
    partial class CustPrimarySecondaryAddresses
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BasicECommerceExample.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StreetAndNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("BasicECommerceExample.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PrimaryAddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SecondaryAddressId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PrimaryAddressId");

                    b.HasIndex("SecondaryAddressId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BasicECommerceExample.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BasicECommerceExample.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BasicECommerceExample.Models.Customer", b =>
                {
                    b.HasOne("BasicECommerceExample.Models.Address", "PrimaryAddress")
                        .WithMany("PrimaryCustomers")
                        .HasForeignKey("PrimaryAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BasicECommerceExample.Models.Address", "SecondaryAddress")
                        .WithMany("SecondaryCustomers")
                        .HasForeignKey("SecondaryAddressId");

                    b.Navigation("PrimaryAddress");

                    b.Navigation("SecondaryAddress");
                });

            modelBuilder.Entity("BasicECommerceExample.Models.Order", b =>
                {
                    b.HasOne("BasicECommerceExample.Models.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BasicECommerceExample.Models.Address", b =>
                {
                    b.Navigation("PrimaryCustomers");

                    b.Navigation("SecondaryCustomers");
                });

            modelBuilder.Entity("BasicECommerceExample.Models.Product", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
