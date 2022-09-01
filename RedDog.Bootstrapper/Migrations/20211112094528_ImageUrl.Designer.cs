﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RedDog.AccountingModel;

namespace RedDog.Bootstrapper.Migrations
{
    [DbContext(typeof(AccountingContext))]
    [Migration("20211112094528_ImageUrl")]
    partial class ImageUrl
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RedDog.AccountingModel.Customer", b =>
                {
                    b.Property<string>("LoyaltyId")
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("LoyaltyId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("RedDog.AccountingModel.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CompletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerLoyaltyId")
                        .HasColumnType("nvarchar(36)");

                    b.Property<decimal>("OrderTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PlacedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StoreId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerLoyaltyId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("RedDog.AccountingModel.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("RedDog.AccountingModel.StoreLocation", b =>
                {
                    b.Property<string>("StoreId")
                        .HasColumnType("nvarchar(54)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(54)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(12,6)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(12,6)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("StateProvince")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("StoreId");

                    b.ToTable("StoreLocation");
                });

            modelBuilder.Entity("RedDog.AccountingModel.Order", b =>
                {
                    b.HasOne("RedDog.AccountingModel.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerLoyaltyId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("RedDog.AccountingModel.OrderItem", b =>
                {
                    b.HasOne("RedDog.AccountingModel.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RedDog.AccountingModel.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
