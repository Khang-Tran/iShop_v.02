﻿// <auto-generated />
using iShop.Data.Entities;
using iShop.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace iShop.Repo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180212183048_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("iShop.Data.Entities.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("iShop.Data.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("City");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("District");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("Ward");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("User");
                });

            modelBuilder.Entity("iShop.Data.Entities.Cart", b =>
                {
                    b.Property<Guid>("ProductId");

                    b.Property<Guid>("ShoppingCartId");

                    b.Property<int>("Quantity");

                    b.HasKey("ProductId", "ShoppingCartId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("iShop.Data.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Detail");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Short");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("iShop.Data.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileName")
                        .IsRequired();

                    b.Property<Guid>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("iShop.Data.Entities.Inventory", b =>
                {
                    b.Property<Guid>("ProductId");

                    b.Property<Guid>("SupplierId");

                    b.Property<Guid>("Id");

                    b.Property<int>("Stock");

                    b.HasKey("ProductId", "SupplierId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.HasIndex("SupplierId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("iShop.Data.Entities.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("InvoiceDate");

                    b.Property<Guid>("OrderId");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("iShop.Data.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("OrderedDate");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("iShop.Data.Entities.OrderedItem", b =>
                {
                    b.Property<Guid>("ProductId");

                    b.Property<Guid>("OrderId");

                    b.Property<int>("Quantity");

                    b.HasKey("ProductId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderedItems");
                });

            modelBuilder.Entity("iShop.Data.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<DateTime>("ExpiredDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<double>("Price");

                    b.Property<string>("Sku");

                    b.Property<string>("Summary");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("iShop.Data.Entities.ProductCategory", b =>
                {
                    b.Property<Guid>("CategoryId");

                    b.Property<Guid>("ProductId");

                    b.HasKey("CategoryId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("iShop.Data.Entities.Shipping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Charge");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("District")
                        .IsRequired();

                    b.Property<Guid>("OrderId");

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<DateTime>("ShippingDate");

                    b.Property<int>("ShippingState");

                    b.Property<string>("UserName");

                    b.Property<string>("Ward")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Shippings");
                });

            modelBuilder.Entity("iShop.Data.Entities.ShoppingCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("PlacedDate");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("iShop.Data.Entities.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OpenIddict.Models.OpenIddictApplication<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientId")
                        .IsRequired();

                    b.Property<string>("ClientSecret");

                    b.Property<string>("DisplayName");

                    b.Property<string>("PostLogoutRedirectUris");

                    b.Property<string>("RedirectUris");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("OpenIddictApplications");
                });

            modelBuilder.Entity("OpenIddict.Models.OpenIddictAuthorization<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ApplicationId");

                    b.Property<string>("Scopes");

                    b.Property<string>("Status")
                        .IsRequired();

                    b.Property<string>("Subject")
                        .IsRequired();

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("OpenIddictAuthorizations");
                });

            modelBuilder.Entity("OpenIddict.Models.OpenIddictScope<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("OpenIddictScopes");
                });

            modelBuilder.Entity("OpenIddict.Models.OpenIddictToken<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ApplicationId");

                    b.Property<Guid?>("AuthorizationId");

                    b.Property<string>("Ciphertext");

                    b.Property<DateTimeOffset?>("CreationDate");

                    b.Property<DateTimeOffset?>("ExpirationDate");

                    b.Property<string>("Hash");

                    b.Property<string>("Status");

                    b.Property<string>("Subject")
                        .IsRequired();

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("AuthorizationId");

                    b.HasIndex("Hash")
                        .IsUnique()
                        .HasFilter("[Hash] IS NOT NULL");

                    b.ToTable("OpenIddictTokens");
                });

            modelBuilder.Entity("iShop.Data.Entities.Cart", b =>
                {
                    b.HasOne("iShop.Data.Entities.Product", "Product")
                        .WithMany("Carts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("iShop.Data.Entities.ShoppingCart", "ShoppingCart")
                        .WithMany("Carts")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("iShop.Data.Entities.Image", b =>
                {
                    b.HasOne("iShop.Data.Entities.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("iShop.Data.Entities.Inventory", b =>
                {
                    b.HasOne("iShop.Data.Entities.Product", "Product")
                        .WithOne("Inventory")
                        .HasForeignKey("iShop.Data.Entities.Inventory", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("iShop.Data.Entities.Supplier", "Supplier")
                        .WithMany("Inventories")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("iShop.Data.Entities.Invoice", b =>
                {
                    b.HasOne("iShop.Data.Entities.Order", "Order")
                        .WithOne("Invoice")
                        .HasForeignKey("iShop.Data.Entities.Invoice", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("iShop.Data.Entities.Order", b =>
                {
                    b.HasOne("iShop.Data.Entities.ApplicationUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("iShop.Data.Entities.OrderedItem", b =>
                {
                    b.HasOne("iShop.Data.Entities.Order", "Order")
                        .WithMany("OrderedItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("iShop.Data.Entities.Product", "Product")
                        .WithMany("OrderedItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("iShop.Data.Entities.ProductCategory", b =>
                {
                    b.HasOne("iShop.Data.Entities.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("iShop.Data.Entities.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("iShop.Data.Entities.Shipping", b =>
                {
                    b.HasOne("iShop.Data.Entities.Order", "Order")
                        .WithOne("Shipping")
                        .HasForeignKey("iShop.Data.Entities.Shipping", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("iShop.Data.Entities.ShoppingCart", b =>
                {
                    b.HasOne("iShop.Data.Entities.ApplicationUser", "User")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("iShop.Data.Entities.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("iShop.Data.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("iShop.Data.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("iShop.Data.Entities.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("iShop.Data.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("iShop.Data.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OpenIddict.Models.OpenIddictAuthorization<System.Guid>", b =>
                {
                    b.HasOne("OpenIddict.Models.OpenIddictApplication<System.Guid>", "Application")
                        .WithMany("Authorizations")
                        .HasForeignKey("ApplicationId");
                });

            modelBuilder.Entity("OpenIddict.Models.OpenIddictToken<System.Guid>", b =>
                {
                    b.HasOne("OpenIddict.Models.OpenIddictApplication<System.Guid>", "Application")
                        .WithMany("Tokens")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OpenIddict.Models.OpenIddictAuthorization<System.Guid>", "Authorization")
                        .WithMany("Tokens")
                        .HasForeignKey("AuthorizationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
