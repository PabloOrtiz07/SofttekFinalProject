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

                    b.Property<double>("Amount")
                        .HasColumnType("float")
                        .HasColumnName("account_amount");

                    b.Property<string>("NameOfCrypto")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("cryptoAccount_description");

                    b.Property<int>("TypeOfAccount")
                        .HasColumnType("int")
                        .HasColumnName("account_typeOfaccount");

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

                    b.HasIndex("Uuid")
                        .IsUnique();

                    b.ToTable("cryptoAccounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 1000.0,
                            NameOfCrypto = "Bitcoin",
                            TypeOfAccount = 2,
                            UserId = 1,
                            Uuid = "CryptoUUID1"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 1500.0,
                            NameOfCrypto = "Ethereum",
                            TypeOfAccount = 2,
                            UserId = 1,
                            Uuid = "CryptoUUID2"
                        },
                        new
                        {
                            Id = 3,
                            Amount = 800.0,
                            NameOfCrypto = "Litecoin",
                            TypeOfAccount = 2,
                            UserId = 2,
                            Uuid = "CryptoUUID3"
                        },
                        new
                        {
                            Id = 4,
                            Amount = 2000.0,
                            NameOfCrypto = "Ripple",
                            TypeOfAccount = 2,
                            UserId = 2,
                            Uuid = "CryptoUUID4"
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
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("fiduciaryAccount_accountNumber");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("fiduciaryAccount_alias");

                    b.Property<double>("Amount")
                        .HasColumnType("float")
                        .HasColumnName("account_amount");

                    b.Property<string>("Cbu")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("fiduciaryAccount_cbu");

                    b.Property<int>("TypeOfAccount")
                        .HasColumnType("int")
                        .HasColumnName("account_typeOfaccount");

                    b.Property<int?>("UserId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("account_user");

                    b.HasKey("Id");

                    b.HasIndex("AccountNumber")
                        .IsUnique();

                    b.HasIndex("Alias")
                        .IsUnique();

                    b.HasIndex("Cbu")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("fiduciaryAccounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountNumber = "12345",
                            Alias = "Alias1",
                            Amount = 500000000.0,
                            Cbu = "CBU1",
                            TypeOfAccount = 0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            AccountNumber = "54321",
                            Alias = "Alias2",
                            Amount = 1000.0,
                            Cbu = "CBU2",
                            TypeOfAccount = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            AccountNumber = "67890",
                            Alias = "Alias3",
                            Amount = 800.0,
                            Cbu = "CBU3",
                            TypeOfAccount = 0,
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            AccountNumber = "98765",
                            Alias = "Alias4",
                            Amount = 1500.0,
                            Cbu = "CBU4",
                            TypeOfAccount = 1,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("SofttekFinalProjectBackend.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DeletedTimeUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("role_deletedTimeUtc");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role_description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("role_isDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role_name");

                    b.HasKey("Id");

                    b.ToTable("roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Administrator",
                            IsDeleted = false,
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            Description = "User",
                            IsDeleted = false,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("SofttekFinalProjectBackend.Entities.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("sale_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float")
                        .HasColumnName("sale_amount");

                    b.Property<string>("CbuAccountPesos")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("sale_cbuaccountpesos");

                    b.Property<DateTime?>("DeletedTimeUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("sale_deletedTimeUtc");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("sale_isDeleted");

                    b.Property<string>("NameOfCrypto")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("sale_description");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("sales");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 100.0,
                            CbuAccountPesos = "CBU1",
                            IsDeleted = false,
                            NameOfCrypto = "bitcoin"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 50.0,
                            CbuAccountPesos = "CBU1",
                            IsDeleted = false,
                            NameOfCrypto = "ethereum"
                        },
                        new
                        {
                            Id = 3,
                            Amount = 75.0,
                            CbuAccountPesos = "CBU3",
                            IsDeleted = false,
                            NameOfCrypto = "bitcoin"
                        },
                        new
                        {
                            Id = 4,
                            Amount = 60.0,
                            CbuAccountPesos = "CBU3",
                            IsDeleted = false,
                            NameOfCrypto = "ethereum"
                        },
                        new
                        {
                            Id = 5,
                            Amount = 1.0,
                            CbuAccountPesos = "CBU3",
                            IsDeleted = false,
                            NameOfCrypto = "bitcoin"
                        });
                });

            modelBuilder.Entity("SofttekFinalProjectBackend.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("transaction_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("CreatedTimeUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("transaction_createdTimeUtc");

                    b.Property<DateTime?>("DeletedTimeUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("transaction_deletedTimeUtc");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("transaction_isDeleted");

                    b.Property<int>("TypeOfOperation")
                        .HasColumnType("int")
                        .HasColumnName("transaction_typeofoperation");

                    b.Property<int?>("UserId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("transaction_user");

                    b.Property<int?>("cryptoAccountDestinationId")
                        .HasColumnType("int");

                    b.Property<int?>("cryptoAccountOriginId")
                        .HasColumnType("int");

                    b.Property<string>("descriptionOperation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("fiduciaryAccountDestinationId")
                        .HasColumnType("int");

                    b.Property<int?>("fiduciaryAccountOriginId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("cryptoAccountDestinationId");

                    b.HasIndex("cryptoAccountOriginId");

                    b.HasIndex("fiduciaryAccountDestinationId");

                    b.HasIndex("fiduciaryAccountOriginId");

                    b.ToTable("transactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 100.0,
                            CreatedTimeUtc = new DateTime(2023, 10, 26, 8, 24, 48, 19, DateTimeKind.Utc).AddTicks(9170),
                            IsDeleted = false,
                            TypeOfOperation = 0,
                            UserId = 1,
                            cryptoAccountOriginId = 1,
                            descriptionOperation = "Sale"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 50.0,
                            CreatedTimeUtc = new DateTime(2023, 10, 26, 8, 24, 48, 19, DateTimeKind.Utc).AddTicks(9175),
                            IsDeleted = false,
                            TypeOfOperation = 1,
                            UserId = 2,
                            descriptionOperation = "Buy",
                            fiduciaryAccountDestinationId = 2,
                            fiduciaryAccountOriginId = 1
                        });
                });

            modelBuilder.Entity("SofttekFinalProjectBackend.Entities.TransactionCrypto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Uuid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TransactionCrypto");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Uuid = "CryptoUUID1"
                        },
                        new
                        {
                            Id = 2,
                            Uuid = "CryptoUUID2"
                        });
                });

            modelBuilder.Entity("SofttekFinalProjectBackend.Entities.TransactionFiduciary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cbu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TransactionFiduciary");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountNumber = "12345",
                            Alias = "Alias1",
                            Cbu = "CBU1"
                        },
                        new
                        {
                            Id = 2,
                            AccountNumber = "54321",
                            Alias = "Alias2",
                            Cbu = "CBU2"
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

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "test@gmail.com",
                            IsDeleted = false,
                            Password = "fa6e018b85c7a6f1512b76a0d8d38a4562580b7a24ddff27bac616548d8639da",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 2,
                            Email = "user1@example.com",
                            IsDeleted = false,
                            Password = "5453e3d9a64595e073a645187c4ab64ca4d851ac409ee9b13e665c6c41759924",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 3,
                            Email = "user2@example.com",
                            IsDeleted = false,
                            Password = "c306b773f2093ae806bdf7b10f298d1ee824d5b519a69bddedb8a688ca4507b3",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 4,
                            Email = "user3@example.com",
                            IsDeleted = false,
                            Password = "f998f7d0cf3ac4a74f4d1384615236a7d191f20100b83ae0633ed734335f1f52",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 5,
                            Email = "user4@example.com",
                            IsDeleted = false,
                            Password = "683c958ae461277b7996eb5156869d3f1b26000fd937297dcdb59fed8f6cab23",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 6,
                            Email = "user5@example.com",
                            IsDeleted = false,
                            Password = "5bb45a32b5f168a072bd9d043ab75e647add3694dfbf2e01c787c0c783292841",
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("SofttekFinalProjectBackend.Entities.CryptoAccount", b =>
                {
                    b.HasOne("SofttekFinalProjectBackend.Entities.User", null)
                        .WithMany("CryptoAccounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SofttekFinalProjectBackend.Entities.FiduciaryAccount", b =>
                {
                    b.HasOne("SofttekFinalProjectBackend.Entities.User", null)
                        .WithMany("FiduciaryAccounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SofttekFinalProjectBackend.Entities.Sale", b =>
                {
                    b.HasOne("SofttekFinalProjectBackend.Entities.User", null)
                        .WithMany("Sales")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SofttekFinalProjectBackend.Entities.Transaction", b =>
                {
                    b.HasOne("SofttekFinalProjectBackend.Entities.User", null)
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SofttekFinalProjectBackend.Entities.TransactionCrypto", "cryptoAccountDestination")
                        .WithMany()
                        .HasForeignKey("cryptoAccountDestinationId");

                    b.HasOne("SofttekFinalProjectBackend.Entities.TransactionCrypto", "cryptoAccountOrigin")
                        .WithMany()
                        .HasForeignKey("cryptoAccountOriginId");

                    b.HasOne("SofttekFinalProjectBackend.Entities.TransactionFiduciary", "fiduciaryAccountDestination")
                        .WithMany()
                        .HasForeignKey("fiduciaryAccountDestinationId");

                    b.HasOne("SofttekFinalProjectBackend.Entities.TransactionFiduciary", "fiduciaryAccountOrigin")
                        .WithMany()
                        .HasForeignKey("fiduciaryAccountOriginId");

                    b.Navigation("cryptoAccountDestination");

                    b.Navigation("cryptoAccountOrigin");

                    b.Navigation("fiduciaryAccountDestination");

                    b.Navigation("fiduciaryAccountOrigin");
                });

            modelBuilder.Entity("SofttekFinalProjectBackend.Entities.User", b =>
                {
                    b.HasOne("SofttekFinalProjectBackend.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SofttekFinalProjectBackend.Entities.User", b =>
                {
                    b.Navigation("CryptoAccounts");

                    b.Navigation("FiduciaryAccounts");

                    b.Navigation("Sales");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
