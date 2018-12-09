﻿// <auto-generated />
using JobTrackerDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace JobTrackerDomain.Migrations
{
    [DbContext(typeof(JobsDbContext))]
    partial class JobsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobTrackerDomain.Models.Client", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("BusinessName")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("InvoicePrefix")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("PrimaryPhone");

                    b.Property<int>("Status");

                    b.HasKey("ID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("JobTrackerDomain.Models.Contact", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ClientID1");

                    b.Property<string>("ContactValue")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("ClientID1");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("JobTrackerDomain.Models.Contact", b =>
                {
                    b.HasOne("JobTrackerDomain.Models.Client")
                        .WithMany("Contacts")
                        .HasForeignKey("ClientID1");
                });
#pragma warning restore 612, 618
        }
    }
}
