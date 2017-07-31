using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BethanysPieShop.Models;

namespace BethanysPieShop.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BethanysPieShop.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.Property<string>("Description");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BethanysPieShop.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("LongDescription");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<bool>("Reserved");

                    b.Property<string>("ShortDescription");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("BethanysPieShop.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("AddressLine2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("OrderPlaced");

                    b.Property<decimal>("OrderTotal");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("State")
                        .HasMaxLength(100);

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BethanysPieShop.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("HotelId");

                    b.Property<int>("OrderId");

                    b.Property<decimal>("Price");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("HotelId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("BethanysPieShop.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int?>("HotelId");

                    b.Property<string>("ShoppingCartId");

                    b.HasKey("ShoppingCartItemId");

                    b.HasIndex("HotelId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("BethanysPieShop.Models.Hotel", b =>
                {
                    b.HasOne("BethanysPieShop.Models.Category", "Category")
                        .WithMany("Hotels")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BethanysPieShop.Models.OrderDetail", b =>
                {
                    b.HasOne("BethanysPieShop.Models.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BethanysPieShop.Models.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BethanysPieShop.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("BethanysPieShop.Models.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId");
                });
        }
    }
}
