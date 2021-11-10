﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Neusta.CompanyService.Database.Contexts;

namespace Neusta.CompanyService.Database.Migrations
{
    [DbContext(typeof(CompanyServiceDbContext))]
    [Migration("20211110212705_CompanyServiceMigration")]
    partial class CompanyServiceMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("Neusta.CompanyService.Database.Entities.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Neusta.CompanyService.Database.Entities.CompanyAttribute", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CompanyAttribute");
                });

            modelBuilder.Entity("Neusta.CompanyService.Database.Entities.CompanyAttributeValue", b =>
                {
                    b.Property<long>("CompanyAttributeId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("CompanyAttributeId", "CompanyId");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyAttributeValue");
                });

            modelBuilder.Entity("Neusta.CompanyService.Database.Entities.CompanyAttributeValue", b =>
                {
                    b.HasOne("Neusta.CompanyService.Database.Entities.CompanyAttribute", null)
                        .WithMany("CompanyAttributeValues")
                        .HasForeignKey("CompanyAttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Neusta.CompanyService.Database.Entities.Company", null)
                        .WithMany("CompanyAttributeValues")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Neusta.CompanyService.Database.Entities.Company", b =>
                {
                    b.Navigation("CompanyAttributeValues");
                });

            modelBuilder.Entity("Neusta.CompanyService.Database.Entities.CompanyAttribute", b =>
                {
                    b.Navigation("CompanyAttributeValues");
                });
#pragma warning restore 612, 618
        }
    }
}
