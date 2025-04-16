﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiSO.Data;

#nullable disable

namespace WebApiSO.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250416004214_AddCustomServiceOrderRegisterEntity")]
    partial class AddCustomServiceOrderRegisterEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FSA.Core.Data.Histories.Track", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Operation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("FSA.Core.Data.Histories.TrackEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FieldName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TrackId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TrackId");

                    b.ToTable("HistoryEntries");
                });

            modelBuilder.Entity("FSA.Core.ServiceOrders.Dtos.ServiceOrderDto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EstimatedEndingDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("ExecutorId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ParentServiceOrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("ServiceOrderTypeId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ServiceOrderDto");
                });

            modelBuilder.Entity("FSA.Core.ServiceOrders.Models.Masters.DocumentType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("FSA.Core.ServiceOrders.Models.Masters.ServiceOrderTaskState", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ServiceOrderTaskStates");
                });

            modelBuilder.Entity("FSA.Core.ServiceOrders.Models.Masters.ServiceOrderType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ServiceOrderTypes");
                });

            modelBuilder.Entity("FSA.Core.ServiceOrders.Models.Masters.SupplyOperation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SupplyOperations");
                });

            modelBuilder.Entity("FSA.Core.ServiceOrders.Models.ServiceOrder", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<DateTime>("EstimatedEndingDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("ExecutorId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ParentServiceOrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("ServiceOrderTypeId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ServiceOrderTypeId");

                    b.ToTable("ServiceOrders");

                    b.HasDiscriminator().HasValue("ServiceOrder");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("FSA.Core.ServiceOrders.Models.ServiceOrderDocument", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("DocumentTypeId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ServiceOrderId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("ServiceOrderId");

                    b.ToTable("ServiceOrderDocuments");
                });

            modelBuilder.Entity("FSA.Core.ServiceOrders.Models.ServiceOrderFeature", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FeatureId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<long>("ServiceOrderId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.Property<string>("Wkt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ServiceOrderId");

                    b.ToTable("ServiceOrderFeatures");
                });

            modelBuilder.Entity("FSA.Core.ServiceOrders.Models.ServiceOrderRegister", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(34)
                        .HasColumnType("nvarchar(34)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Observations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ServiceOrderId")
                        .HasColumnType("bigint");

                    b.Property<string>("StateFrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trigger")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ServiceOrderId");

                    b.ToTable("ServiceOrderRegisters");

                    b.HasDiscriminator().HasValue("ServiceOrderRegister");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("FSA.Core.ServiceOrders.Models.ServiceOrderTask", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExecutionDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Observations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ServiceOrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("ServiceOrderTaskStateId")
                        .HasColumnType("bigint");

                    b.Property<string>("TypeEntity")
                        .IsRequired()
                        .HasMaxLength(34)
                        .HasColumnType("nvarchar(34)");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ServiceOrderId");

                    b.HasIndex("ServiceOrderTaskStateId");

                    b.ToTable("ServiceOrderTasks");

                    b.HasDiscriminator<string>("TypeEntity").HasValue("ServiceOrderTask");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("FSA.Core.ServiceOrders.Models.ServiceOrderTaskDocument", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("DocumentTypeId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ServiceOrderTaskId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("ServiceOrderTaskId");

                    b.ToTable("ServiceOrderTaskDocuments");
                });

            modelBuilder.Entity("FSA.Core.ServiceOrders.Models.Supply", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<long>("ServiceOrderTaskId")
                        .HasColumnType("bigint");

                    b.Property<long>("SupplyOperationId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ServiceOrderTaskId");

                    b.HasIndex("SupplyOperationId");

                    b.ToTable("Supplies");
                });

            modelBuilder.Entity("WebApiSO.Models.CustomServiceOrder", b =>
                {
                    b.HasBaseType("FSA.Core.ServiceOrders.Models.ServiceOrder");

                    b.Property<int>("CustomField")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("CustomServiceOrder");
                });

            modelBuilder.Entity("WebApiSO.Models.CustomServiceOrderRegister", b =>
                {
                    b.HasBaseType("FSA.Core.ServiceOrders.Models.ServiceOrderRegister");

                    b.Property<long?>("SOId")
                        .HasColumnType("bigint");

                    b.HasIndex("SOId");

                    b.HasDiscriminator().HasValue("CustomServiceOrderRegister");
                });

            modelBuilder.Entity("WebApiSO.Models.CustomServiceOrderTask", b =>
                {
                    b.HasBaseType("FSA.Core.ServiceOrders.Models.ServiceOrderTask");

                    b.Property<string>("CustomFieldSOTask")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("CustomServiceOrderTask");
                });

            modelBuilder.Entity("FSA.Core.Data.Histories.TrackEntry", b =>
                {
                    b.HasOne("FSA.Core.Data.Histories.Track", null)
                        .WithMany("Changes")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FSA.Core.ServiceOrders.Models.ServiceOrder", b =>
                {
                    b.HasOne("FSA.Core.ServiceOrders.Models.Masters.ServiceOrderType", "Type")
                        .WithMany()
                        .HasForeignKey("ServiceOrderTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("FSA.Core.ServiceOrders.Models.ServiceOrderDocument", b =>
                {
                    b.HasOne("FSA.Core.ServiceOrders.Models.Masters.DocumentType", "Type")
                        .WithMany()
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FSA.Core.ServiceOrders.Models.ServiceOrder", null)
                        .WithMany("Documents")
                        .HasForeignKey("ServiceOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("FSA.Core.ServiceOrders.Models.ServiceOrderFeature", b =>
                {
                    b.HasOne("FSA.Core.ServiceOrders.Models.ServiceOrder", null)
                        .WithMany("Features")
                        .HasForeignKey("ServiceOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FSA.Core.ServiceOrders.Models.ServiceOrderRegister", b =>
                {
                    b.HasOne("FSA.Core.ServiceOrders.Models.ServiceOrder", null)
                        .WithMany("Registers")
                        .HasForeignKey("ServiceOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FSA.Core.ServiceOrders.Models.ServiceOrderTask", b =>
                {
                    b.HasOne("FSA.Core.ServiceOrders.Models.ServiceOrder", null)
                        .WithMany("Tasks")
                        .HasForeignKey("ServiceOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FSA.Core.ServiceOrders.Models.Masters.ServiceOrderTaskState", "State")
                        .WithMany()
                        .HasForeignKey("ServiceOrderTaskStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("FSA.Core.ServiceOrders.Models.ServiceOrderTaskDocument", b =>
                {
                    b.HasOne("FSA.Core.ServiceOrders.Models.Masters.DocumentType", "Type")
                        .WithMany()
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FSA.Core.ServiceOrders.Models.ServiceOrderTask", null)
                        .WithMany("Documents")
                        .HasForeignKey("ServiceOrderTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("FSA.Core.ServiceOrders.Models.Supply", b =>
                {
                    b.HasOne("FSA.Core.ServiceOrders.Models.ServiceOrderTask", null)
                        .WithMany("Supplies")
                        .HasForeignKey("ServiceOrderTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FSA.Core.ServiceOrders.Models.Masters.SupplyOperation", "Operation")
                        .WithMany()
                        .HasForeignKey("SupplyOperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operation");
                });

            modelBuilder.Entity("WebApiSO.Models.CustomServiceOrderRegister", b =>
                {
                    b.HasOne("FSA.Core.ServiceOrders.Dtos.ServiceOrderDto", "ServiceOrder")
                        .WithMany()
                        .HasForeignKey("SOId");

                    b.Navigation("ServiceOrder");
                });

            modelBuilder.Entity("FSA.Core.Data.Histories.Track", b =>
                {
                    b.Navigation("Changes");
                });

            modelBuilder.Entity("FSA.Core.ServiceOrders.Models.ServiceOrder", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("Features");

                    b.Navigation("Registers");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("FSA.Core.ServiceOrders.Models.ServiceOrderTask", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("Supplies");
                });
#pragma warning restore 612, 618
        }
    }
}
