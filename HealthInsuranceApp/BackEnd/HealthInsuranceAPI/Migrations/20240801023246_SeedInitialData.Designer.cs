﻿// <auto-generated />
using System;
using HealthInsuranceApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthInsuranceAPI.Migrations
{
    [DbContext(typeof(HealthInsuranceAppContext))]
    [Migration("20240801023246_SeedInitialData")]
    partial class SeedInitialData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HealthInsuranceAPI.Models.Agent", b =>
                {
                    b.Property<Guid>("AgentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AgentID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Agents");

                    b.HasData(
                        new
                        {
                            AgentID = new Guid("16f76b08-0f6b-4d8d-a963-d0c99769f895"),
                            ContactNumber = "123-456-7890",
                            Name = "Ram",
                            UserID = new Guid("41a55ded-7c05-4058-9e63-1f5a8fafe4db")
                        });
                });

            modelBuilder.Entity("HealthInsuranceAPI.Models.Claim", b =>
                {
                    b.Property<Guid>("ClaimID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ClaimAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ClaimDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ClaimStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("CustomerPolicyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClaimID");

                    b.HasIndex("CustomerPolicyID");

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("HealthInsuranceAPI.Models.Customer", b =>
                {
                    b.Property<Guid>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CustomerID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerID = new Guid("122b2296-0995-479a-bee8-116d0ecd3c91"),
                            Address = "123 Main St",
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Arun",
                            Phone = "555-1234",
                            UserID = new Guid("d1c60656-dea3-4942-857f-1f4a2c715265")
                        },
                        new
                        {
                            CustomerID = new Guid("2d7be1a6-f829-43c0-86a5-98a04501b3d7"),
                            Address = "456 Elm St",
                            DateOfBirth = new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Shangu",
                            Phone = "555-5678",
                            UserID = new Guid("3fc25cd0-27c8-4a44-900f-1697b7f8171c")
                        });
                });

            modelBuilder.Entity("HealthInsuranceAPI.Models.CustomerPolicy", b =>
                {
                    b.Property<Guid>("CustomerPolicyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("DiscountEligibility")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PolicyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("CustomerPolicyID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("PolicyID");

                    b.ToTable("CustomerPolicies");
                });

            modelBuilder.Entity("HealthInsuranceAPI.Models.InsurancePolicy", b =>
                {
                    b.Property<Guid>("PolicyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("CoverageAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PolicyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PolicyNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolicyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PremiumAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RenewalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PolicyID");

                    b.ToTable("InsurancePolicies");

                    b.HasData(
                        new
                        {
                            PolicyID = new Guid("fb90d054-1339-4d45-b968-7c46ff02f5e2"),
                            CoverageAmount = 100000m,
                            EndDate = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PolicyName = "Health Insurance Plan A",
                            PolicyNumber = "HIPA001",
                            PolicyType = "Health",
                            PremiumAmount = 1000m,
                            RenewalAmount = 900m,
                            StartDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            PolicyID = new Guid("7feae666-b096-4c7c-a56c-23666a2b0d57"),
                            CoverageAmount = 500000m,
                            EndDate = new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PolicyName = "Life Insurance Plan B",
                            PolicyNumber = "LIPB002",
                            PolicyType = "Life",
                            PremiumAmount = 2000m,
                            RenewalAmount = 1800m,
                            StartDate = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("HealthInsuranceAPI.Models.Payment", b =>
                {
                    b.Property<Guid>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerPolicyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PaymentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.HasKey("PaymentID");

                    b.HasIndex("CustomerPolicyID");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("HealthInsuranceAPI.Models.Renewal", b =>
                {
                    b.Property<Guid>("RenewalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerPolicyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("DiscountApplied")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRenewed")
                        .HasColumnType("bit");

                    b.Property<decimal>("RenewalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("RenewalDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RenewalID");

                    b.HasIndex("CustomerPolicyID");

                    b.ToTable("Renewals");
                });

            modelBuilder.Entity("HealthInsuranceAPI.Models.Revival", b =>
                {
                    b.Property<Guid>("RevivalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerPolicyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RevivalDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RevivalID");

                    b.HasIndex("CustomerPolicyID");

                    b.ToTable("Revivals");
                });

            modelBuilder.Entity("HealthInsuranceAPI.Models.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varbinary(100)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HealthInsuranceAPI.Models.Agent", b =>
                {
                    b.HasOne("HealthInsuranceAPI.Models.User", "User")
                        .WithOne()
                        .HasForeignKey("HealthInsuranceAPI.Models.Agent", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HealthInsuranceAPI.Models.Claim", b =>
                {
                    b.HasOne("HealthInsuranceAPI.Models.CustomerPolicy", "CustomerPolicy")
                        .WithMany("Claims")
                        .HasForeignKey("CustomerPolicyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerPolicy");
                });

            modelBuilder.Entity("HealthInsuranceAPI.Models.Customer", b =>
                {
                    b.HasOne("HealthInsuranceAPI.Models.User", "User")
                        .WithOne()
                        .HasForeignKey("HealthInsuranceAPI.Models.Customer", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HealthInsuranceAPI.Models.CustomerPolicy", b =>
                {
                    b.HasOne("HealthInsuranceAPI.Models.Customer", "Customer")
                        .WithMany("CustomerPolicies")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthInsuranceAPI.Models.InsurancePolicy", "InsurancePolicy")
                        .WithMany()
                        .HasForeignKey("PolicyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("InsurancePolicy");
                });

            modelBuilder.Entity("HealthInsuranceAPI.Models.Payment", b =>
                {
                    b.HasOne("HealthInsuranceAPI.Models.CustomerPolicy", "CustomerPolicy")
                        .WithMany("Payments")
                        .HasForeignKey("CustomerPolicyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerPolicy");
                });

            modelBuilder.Entity("HealthInsuranceAPI.Models.Renewal", b =>
                {
                    b.HasOne("HealthInsuranceAPI.Models.CustomerPolicy", "CustomerPolicy")
                        .WithMany("Renewals")
                        .HasForeignKey("CustomerPolicyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerPolicy");
                });

            modelBuilder.Entity("HealthInsuranceAPI.Models.Revival", b =>
                {
                    b.HasOne("HealthInsuranceAPI.Models.CustomerPolicy", "CustomerPolicy")
                        .WithMany("Revivals")
                        .HasForeignKey("CustomerPolicyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerPolicy");
                });

            modelBuilder.Entity("HealthInsuranceAPI.Models.Customer", b =>
                {
                    b.Navigation("CustomerPolicies");
                });

            modelBuilder.Entity("HealthInsuranceAPI.Models.CustomerPolicy", b =>
                {
                    b.Navigation("Claims");

                    b.Navigation("Payments");

                    b.Navigation("Renewals");

                    b.Navigation("Revivals");
                });
#pragma warning restore 612, 618
        }
    }
}
