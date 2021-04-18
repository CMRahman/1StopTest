﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(OneStopDbContext))]
    partial class OneStopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Balance")
                        .HasColumnType("decimal(19,2)");

                    b.Property<DateTime>("CreatedOn")
                        .HasPrecision(3)
                        .HasColumnType("datetime2(3)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasPrecision(3)
                        .HasColumnType("datetime2(3)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AccountId");

                    b.HasIndex("UserId1");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasPrecision(3)
                        .HasColumnType("datetime2(3)");

                    b.Property<int>("PostCode")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasPrecision(3)
                        .HasColumnType("datetime2(3)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasPrecision(3)
                        .HasColumnType("datetime2(3)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasPrecision(3)
                        .HasColumnType("datetime2(3)");

                    b.Property<string>("UserName")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("UserId");

                    b.HasIndex("AddressId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Domain.Entities.Account", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany("Accounts")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
