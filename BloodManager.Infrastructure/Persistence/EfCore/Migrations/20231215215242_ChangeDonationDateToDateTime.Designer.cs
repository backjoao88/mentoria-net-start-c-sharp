﻿// <auto-generated />
using System;
using BloodManager.Infrastructure.Persistence.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BloodManager.Infrastructure.Persistence.EfCore.Migrations
{
    [DbContext(typeof(EfCoreContext))]
    [Migration("20231215215242_ChangeDonationDateToDateTime")]
    partial class ChangeDonationDateToDateTime
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BloodManager.Core.Entities.Donation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DonationDate")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("DonorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdDonor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("QuantityMl")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DonorId");

                    b.HasIndex("IdDonor");

                    b.ToTable("tbl_Donation", (string)null);
                });

            modelBuilder.Entity("BloodManager.Core.Entities.Donor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birth")
                        .HasColumnType("datetime2");

                    b.Property<int>("BloodType")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RhFactorType")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tbl_Donor", (string)null);
                });

            modelBuilder.Entity("BloodManager.Core.Entities.Stock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BloodType")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("RhFactorType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tbl_Stock", (string)null);
                });

            modelBuilder.Entity("BloodManager.Core.Entities.Donation", b =>
                {
                    b.HasOne("BloodManager.Core.Entities.Donor", "Donor")
                        .WithMany()
                        .HasForeignKey("DonorId");

                    b.HasOne("BloodManager.Core.Entities.Donor", null)
                        .WithMany("Donations")
                        .HasForeignKey("IdDonor");

                    b.Navigation("Donor");
                });

            modelBuilder.Entity("BloodManager.Core.Entities.Donor", b =>
                {
                    b.OwnsOne("BloodManager.Core.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("DonorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DonorId");

                            b1.ToTable("tbl_Donor");

                            b1.WithOwner()
                                .HasForeignKey("DonorId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("BloodManager.Core.Entities.Donor", b =>
                {
                    b.Navigation("Donations");
                });
#pragma warning restore 612, 618
        }
    }
}