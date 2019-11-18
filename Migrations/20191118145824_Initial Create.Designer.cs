﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MobileStore.Models;

namespace MobileStore.Migrations
{
    [DbContext(typeof(MobileContext))]
    [Migration("20191118145824_Initial Create")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MobileStore.Models.AccessoryItems", b =>
                {
                    b.Property<int>("AccessoryItemsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AccessoryPrice")
                        .HasColumnType("int");

                    b.Property<int>("MobileItemsId")
                        .HasColumnType("int");

                    b.HasKey("AccessoryItemsId");

                    b.HasIndex("MobileItemsId");

                    b.ToTable("AccessoryItems");
                });

            modelBuilder.Entity("MobileStore.Models.MobileItems", b =>
                {
                    b.Property<int>("MobileItemsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MobileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MobilePrice")
                        .HasColumnType("int");

                    b.HasKey("MobileItemsId");

                    b.ToTable("MobileItems");
                });

            modelBuilder.Entity("MobileStore.Models.AccessoryItems", b =>
                {
                    b.HasOne("MobileStore.Models.MobileItems", "MobileItems")
                        .WithMany()
                        .HasForeignKey("MobileItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
