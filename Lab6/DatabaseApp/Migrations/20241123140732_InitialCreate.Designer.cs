﻿// <auto-generated />
using System;
using DatabaseApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DatabaseApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241123140732_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("DatabaseApp.Models.Asset", b =>
                {
                    b.Property<int>("AssetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AssetName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AssetTypeCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OtherDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SizeCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AssetID");

                    b.HasIndex("AssetTypeCode");

                    b.HasIndex("SizeCode");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("DatabaseApp.Models.AssetLifeCycleEvent", b =>
                {
                    b.Property<int>("AssetLifeCycleEventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AssetID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("TEXT");

                    b.Property<string>("LifeCycleCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LocationID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PartyID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StatusCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AssetLifeCycleEventID");

                    b.HasIndex("AssetID");

                    b.HasIndex("LifeCycleCode");

                    b.HasIndex("LocationID");

                    b.HasIndex("PartyID");

                    b.HasIndex("StatusCode");

                    b.ToTable("AssetLifeCycleEvents");
                });

            modelBuilder.Entity("DatabaseApp.Models.LifeCyclePhase", b =>
                {
                    b.Property<string>("LifeCycleCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("LifeCycleDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LifeCycleName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LifeCycleCode");

                    b.ToTable("LifeCyclePhases");
                });

            modelBuilder.Entity("DatabaseApp.Models.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LocationDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LocationID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("DatabaseApp.Models.RefAssetCategory", b =>
                {
                    b.Property<string>("AssetCategoryCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("AssetCategoryDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AssetCategoryCode");

                    b.ToTable("RefAssetCategories");
                });

            modelBuilder.Entity("DatabaseApp.Models.RefAssetSupertype", b =>
                {
                    b.Property<string>("AssetSupertypeCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("AssetCategoryCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AssetSupertypeDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AssetSupertypeCode");

                    b.HasIndex("AssetCategoryCode");

                    b.ToTable("RefAssetSupertypes");
                });

            modelBuilder.Entity("DatabaseApp.Models.RefAssetType", b =>
                {
                    b.Property<string>("AssetTypeCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("AssetSupertypeCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AssetTypeDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AssetTypeCode");

                    b.HasIndex("AssetSupertypeCode");

                    b.ToTable("RefAssetTypes");
                });

            modelBuilder.Entity("DatabaseApp.Models.RefSize", b =>
                {
                    b.Property<string>("SizeCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("SizeDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SizeCode");

                    b.ToTable("RefSizes");
                });

            modelBuilder.Entity("DatabaseApp.Models.RefStatus", b =>
                {
                    b.Property<string>("StatusCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("StatusDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StatusCode");

                    b.ToTable("RefStatuses");
                });

            modelBuilder.Entity("DatabaseApp.Models.ResponsibleParty", b =>
                {
                    b.Property<int>("PartyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PartyDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PartyID");

                    b.ToTable("ResponsibleParties");
                });

            modelBuilder.Entity("DatabaseApp.Models.Asset", b =>
                {
                    b.HasOne("DatabaseApp.Models.RefAssetType", "RefAssetType")
                        .WithMany()
                        .HasForeignKey("AssetTypeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseApp.Models.RefSize", "RefSize")
                        .WithMany()
                        .HasForeignKey("SizeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RefAssetType");

                    b.Navigation("RefSize");
                });

            modelBuilder.Entity("DatabaseApp.Models.AssetLifeCycleEvent", b =>
                {
                    b.HasOne("DatabaseApp.Models.Asset", "Asset")
                        .WithMany()
                        .HasForeignKey("AssetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseApp.Models.LifeCyclePhase", "LifeCyclePhase")
                        .WithMany()
                        .HasForeignKey("LifeCycleCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseApp.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseApp.Models.ResponsibleParty", "ResponsibleParty")
                        .WithMany()
                        .HasForeignKey("PartyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseApp.Models.RefStatus", "RefStatus")
                        .WithMany()
                        .HasForeignKey("StatusCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("LifeCyclePhase");

                    b.Navigation("Location");

                    b.Navigation("RefStatus");

                    b.Navigation("ResponsibleParty");
                });

            modelBuilder.Entity("DatabaseApp.Models.RefAssetSupertype", b =>
                {
                    b.HasOne("DatabaseApp.Models.RefAssetCategory", "RefAssetCategory")
                        .WithMany()
                        .HasForeignKey("AssetCategoryCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RefAssetCategory");
                });

            modelBuilder.Entity("DatabaseApp.Models.RefAssetType", b =>
                {
                    b.HasOne("DatabaseApp.Models.RefAssetSupertype", "RefAssetSupertype")
                        .WithMany()
                        .HasForeignKey("AssetSupertypeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RefAssetSupertype");
                });
#pragma warning restore 612, 618
        }
    }
}