﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using InterviewSample.Data;

namespace InterviewSample.Migrations
{
    [DbContext(typeof(ContactsContext))]
    [Migration("20170418001419_FKID")]
    partial class FKID
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InterviewSample.Models.Addresses", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("City");

                    b.Property<int>("ContactNum");

                    b.Property<int?>("ContactsID");

                    b.Property<string>("Name");

                    b.Property<string>("StateCode")
                        .HasMaxLength(40);

                    b.Property<string>("Zip")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("ContactsID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("InterviewSample.Models.Contacts", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("NumberOfComputers");

                    b.HasKey("ID");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("InterviewSample.Models.Addresses", b =>
                {
                    b.HasOne("InterviewSample.Models.Contacts")
                        .WithMany("Addresses")
                        .HasForeignKey("ContactsID");
                });
        }
    }
}
