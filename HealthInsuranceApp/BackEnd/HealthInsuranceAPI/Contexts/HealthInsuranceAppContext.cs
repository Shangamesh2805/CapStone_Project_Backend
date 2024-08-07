﻿using Microsoft.EntityFrameworkCore;
using HealthInsuranceAPI.Models;

namespace HealthInsuranceApp.Data
{
    public class HealthInsuranceAppContext : DbContext
    {
        public HealthInsuranceAppContext(DbContextOptions<HealthInsuranceAppContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
        public DbSet<CustomerPolicy> CustomerPolicies { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Renewal> Renewals { get; set; }
        public DbSet<Revival> Revivals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User - Customer one-to-one relationship
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.User)
                .WithOne()
                .HasForeignKey<Customer>(c => c.UserID);

            // User - Agent one-to-one relationship
            modelBuilder.Entity<Agent>()
                .HasOne(a => a.User)
                .WithOne()
                .HasForeignKey<Agent>(a => a.UserID);

            // Customer - CustomerPolicy one-to-many relationship
            modelBuilder.Entity<CustomerPolicy>()
                .HasOne(cp => cp.Customer)
                .WithMany(c => c.CustomerPolicies)
                .HasForeignKey(cp => cp.CustomerID);

            // InsurancePolicy - CustomerPolicy many-to-one relationship
            modelBuilder.Entity<CustomerPolicy>()
                .HasOne(cp => cp.InsurancePolicy)
                .WithMany()
                .HasForeignKey(cp => cp.PolicyID);

            // CustomerPolicy - Claim one-to-many relationship
            modelBuilder.Entity<Claim>()
                .HasOne(cl => cl.CustomerPolicy)
                .WithMany(cp => cp.Claims)
                .HasForeignKey(cl => cl.CustomerPolicyID);

            // CustomerPolicy - Payment one-to-many relationship
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.CustomerPolicy)
                .WithMany(cp => cp.Payments)
                .HasForeignKey(p => p.CustomerPolicyID);

            // CustomerPolicy - Renewal one-to-many relationship
            modelBuilder.Entity<Renewal>()
                .HasOne(r => r.CustomerPolicy)
                .WithMany(cp => cp.Renewals)
                .HasForeignKey(r => r.CustomerPolicyID);

            // CustomerPolicy - Revival one-to-many relationship
            modelBuilder.Entity<Revival>()
                .HasOne(r => r.CustomerPolicy)
                .WithMany(cp => cp.Revivals)
                .HasForeignKey(r => r.CustomerPolicyID);

            // Ensure GUIDs are generated by the database
            modelBuilder.Entity<User>()
                .Property(u => u.UserID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Customer>()
                .Property(c => c.CustomerID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Agent>()
                .Property(a => a.AgentID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<InsurancePolicy>()
                .Property(ip => ip.PolicyID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CustomerPolicy>()
                .Property(cp => cp.CustomerPolicyID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Claim>()
                .Property(cl => cl.ClaimID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Renewal>()
                .Property(r => r.RenewalID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Revival>()
                .Property(r => r.RevivalID)
                .ValueGeneratedOnAdd();

            

            var agentUserId = new Guid("41A55DED-7C05-4058-9E63-1F5A8FAFE4DB");
            var customerUserId = new Guid("D1C60656-DEA3-4942-857F-1F4A2C715265");

            // Seed Agents
            modelBuilder.Entity<Agent>().HasData(
                new Agent
                {
                    AgentID = Guid.NewGuid(),
                    UserID = agentUserId,
                    Name = "Ram",
                    ContactNumber = "123-456-7890"
                }
            );

            // Seed Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerID = Guid.NewGuid(),
                    UserID = customerUserId,
                    Name = "Arun",
                    Address = "123 Main St",
                    Phone = "555-1234",
                    DateOfBirth = new DateTime(1990, 1, 1)
                },
                new Customer
                {
                    CustomerID = Guid.NewGuid(),
                    UserID = new Guid("3FC25CD0-27C8-4A44-900F-1697B7F8171C"), 
                    Name = "Shangu",
                    Address = "456 Elm St",
                    Phone = "555-5678",
                    DateOfBirth = new DateTime(1985, 5, 15)
                }
            );

            // Seed Insurance Policies
            modelBuilder.Entity<InsurancePolicy>().HasData(
                new InsurancePolicy
                {
                    PolicyID = Guid.NewGuid(),
                    PolicyName = "Health Insurance Plan A",
                    PolicyNumber = "HIPA001",
                    PolicyType = "Health",
                    CoverageAmount = 100000,
                    PremiumAmount = 1000,
                    RenewalAmount = 900,
                    StartDate = new DateTime(2023, 1, 1),
                    EndDate = new DateTime(2024, 1, 1)
                },
                new InsurancePolicy
                {
                    PolicyID = Guid.NewGuid(),
                    PolicyName = "Life Insurance Plan B",
                    PolicyNumber = "LIPB002",
                    PolicyType = "Life",
                    CoverageAmount = 500000,
                    PremiumAmount = 2000,
                    RenewalAmount = 1800,
                    StartDate = new DateTime(2023, 6, 1),
                    EndDate = new DateTime(2024, 6, 1)
                }
                );
                
        }
    }
}
