﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SofttekFinalProjectBackend.DataAccess;

#nullable disable

namespace SofttekFinalProjectBackend.Migrations
{
    [DbContext(typeof(ContextDB))]
    partial class ContextDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SofttekFinalProjectBackend.Entities.CryptoAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("account_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("account_amount");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("cryptoAccount_description");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("account_sortofaccount");

                    b.Property<int?>("UserId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("account_user");

                    b.Property<string>("Uuid")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("cryptoAccount_uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("cryptoAccount");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 1000,
                            Description = "Bitcoin",
                            Status = 2,
                            UserId = 1,
                            Uuid = "CryptoUUID1"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 1500,
                            Description = "Ethereum",
                            Status = 2,
                            UserId = 1,
                            Uuid = "CryptoUUID2"
                        });
                });

            modelBuilder.Entity("SofttekFinalProjectBackend.Entities.FiduciaryAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("account_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("fiduciaryAccount_accountNumber");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("fiduciaryAccount_alias");

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("account_amount");

                    b.Property<string>("Cbu")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("fiduciaryAccount_cbu");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("account_sortofaccount");

                    b.Property<int?>("UserId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("account_user");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("fiduciaryAccount");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountNumber = "12345",
                            Alias = "Alias1",
                            Amount = 500,
                            Cbu = "CBU1",
                            Status = 0,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("SofttekFinalProjectBackend.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DeletedTimeUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("user_deletedTimeUtc");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("user_email");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("user_isDeleted");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("user_password");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "test@gmail.com",
                            IsDeleted = false,
                            Password = "fa6e018b85c7a6f1512b76a0d8d38a4562580b7a24ddff27bac616548d8639da"
                        });
                });

            modelBuilder.Entity("SofttekFinalProjectBackend.Entities.CryptoAccount", b =>
                {
                    b.HasOne("SofttekFinalProjectBackend.Entities.User", "User")
                        .WithMany("CryptoAccounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SofttekFinalProjectBackend.Entities.FiduciaryAccount", b =>
                {
                    b.HasOne("SofttekFinalProjectBackend.Entities.User", "User")
                        .WithMany("FiduciaryAccounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SofttekFinalProjectBackend.Entities.User", b =>
                {
                    b.Navigation("CryptoAccounts");

                    b.Navigation("FiduciaryAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
