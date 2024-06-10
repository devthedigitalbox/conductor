﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkflowCore.Persistence.SqlServer;

namespace WorkflowCore.Persistence.SqlServer.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    [Migration("20210109172432_EFCore5")]
    partial class EFCore5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedEvent", b =>
                {
                    b.Property<long>("PersistenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("EventData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EventKey")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("EventName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("EventTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsProcessed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsQueued")
                        .HasColumnType("bit");

                    b.HasKey("PersistenceId");

                    b.HasIndex("EventId")
                        .IsUnique();

                    b.HasIndex("EventTime");

                    b.HasIndex("IsProcessed");

                    b.HasIndex("EventName", "EventKey");

                    b.ToTable("Event", "wfc");
                });

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedExecutionError", b =>
                {
                    b.Property<long>("PersistenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("ErrorTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExecutionPointerId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkflowId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PersistenceId");

                    b.ToTable("ExecutionError", "wfc");
                });

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedExecutionPointer", b =>
                {
                    b.Property<long>("PersistenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Children")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContextItem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventKey")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EventName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("EventPublished")
                        .HasColumnType("bit");

                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Outcome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersistenceData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PredecessorId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RetryCount")
                        .HasColumnType("int");

                    b.Property<string>("Scope")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SleepUntil")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("StepId")
                        .HasColumnType("int");

                    b.Property<string>("StepName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("WorkflowId")
                        .HasColumnType("bigint");

                    b.HasKey("PersistenceId");

                    b.HasIndex("WorkflowId");

                    b.ToTable("ExecutionPointer", "wfc");
                });

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedExtensionAttribute", b =>
                {
                    b.Property<long>("PersistenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("AttributeKey")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("AttributeValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ExecutionPointerId")
                        .HasColumnType("bigint");

                    b.HasKey("PersistenceId");

                    b.HasIndex("ExecutionPointerId");

                    b.ToTable("ExtensionAttribute", "wfc");
                });

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedSubscription", b =>
                {
                    b.Property<long>("PersistenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("EventKey")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("EventName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ExecutionPointerId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ExternalToken")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ExternalTokenExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExternalWorkerId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("StepId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubscribeAsOf")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubscriptionData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SubscriptionId")
                        .HasMaxLength(200)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WorkflowId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("PersistenceId");

                    b.HasIndex("EventKey");

                    b.HasIndex("EventName");

                    b.HasIndex("SubscriptionId")
                        .IsUnique();

                    b.ToTable("Subscription", "wfc");
                });

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedWorkflow", b =>
                {
                    b.Property<long>("PersistenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("CompleteTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("InstanceId")
                        .HasMaxLength(200)
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("NextExecution")
                        .HasColumnType("bigint");

                    b.Property<string>("Reference")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<string>("WorkflowDefinitionId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("PersistenceId");

                    b.HasIndex("InstanceId")
                        .IsUnique();

                    b.HasIndex("NextExecution");

                    b.ToTable("Workflow", "wfc");
                });

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedExecutionPointer", b =>
                {
                    b.HasOne("WorkflowCore.Persistence.EntityFramework.Models.PersistedWorkflow", "Workflow")
                        .WithMany("ExecutionPointers")
                        .HasForeignKey("WorkflowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workflow");
                });

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedExtensionAttribute", b =>
                {
                    b.HasOne("WorkflowCore.Persistence.EntityFramework.Models.PersistedExecutionPointer", "ExecutionPointer")
                        .WithMany("ExtensionAttributes")
                        .HasForeignKey("ExecutionPointerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExecutionPointer");
                });

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedExecutionPointer", b =>
                {
                    b.Navigation("ExtensionAttributes");
                });

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedWorkflow", b =>
                {
                    b.Navigation("ExecutionPointers");
                });
#pragma warning restore 612, 618
        }
    }
}
