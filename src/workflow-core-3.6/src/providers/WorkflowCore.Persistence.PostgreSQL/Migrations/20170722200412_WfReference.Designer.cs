﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WorkflowCore.Persistence.PostgreSQL;
using WorkflowCore.Models;

namespace WorkflowCore.Persistence.PostgreSQL.Migrations
{
    [DbContext(typeof(PostgresContext))]
    [Migration("20170722200412_WfReference")]
    partial class WfReference
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedEvent", b =>
                {
                    b.Property<long>("PersistenceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EventData");

                    b.Property<Guid>("EventId");

                    b.Property<string>("EventKey")
                        .HasMaxLength(200);

                    b.Property<string>("EventName")
                        .HasMaxLength(200);

                    b.Property<DateTime>("EventTime");

                    b.Property<bool>("IsProcessed");

                    b.Property<bool>("IsQueued");

                    b.HasKey("PersistenceId");

                    b.HasIndex("EventId")
                        .IsUnique();

                    b.HasIndex("EventTime");

                    b.HasIndex("IsProcessed");

                    b.HasIndex("EventName", "EventKey");

                    b.ToTable("PersistedEvent");

                    b.HasAnnotation("Npgsql:Schema", "wfc");

                    b.HasAnnotation("Npgsql:TableName", "Event");
                });

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedExecutionError", b =>
                {
                    b.Property<long>("PersistenceId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ErrorTime");

                    b.Property<string>("ExecutionPointerId")
                        .HasMaxLength(100);

                    b.Property<string>("Message");

                    b.Property<string>("WorkflowId")
                        .HasMaxLength(100);

                    b.HasKey("PersistenceId");

                    b.ToTable("PersistedExecutionError");

                    b.HasAnnotation("Npgsql:Schema", "wfc");

                    b.HasAnnotation("Npgsql:TableName", "ExecutionError");
                });

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedExecutionPointer", b =>
                {
                    b.Property<long>("PersistenceId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Children");

                    b.Property<string>("ContextItem");

                    b.Property<DateTime?>("EndTime");

                    b.Property<string>("EventData");

                    b.Property<string>("EventKey")
                        .HasMaxLength(100);

                    b.Property<string>("EventName")
                        .HasMaxLength(100);

                    b.Property<bool>("EventPublished");

                    b.Property<string>("Id")
                        .HasMaxLength(50);

                    b.Property<string>("Outcome");

                    b.Property<string>("PersistenceData");

                    b.Property<string>("PredecessorId")
                        .HasMaxLength(100);

                    b.Property<int>("RetryCount");

                    b.Property<DateTime?>("SleepUntil");

                    b.Property<DateTime?>("StartTime");

                    b.Property<int>("StepId");

                    b.Property<string>("StepName")
                        .HasMaxLength(100);

                    b.Property<long>("WorkflowId");

                    b.HasKey("PersistenceId");

                    b.HasIndex("WorkflowId");

                    b.ToTable("PersistedExecutionPointer");

                    b.HasAnnotation("Npgsql:Schema", "wfc");

                    b.HasAnnotation("Npgsql:TableName", "ExecutionPointer");
                });

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedExtensionAttribute", b =>
                {
                    b.Property<long>("PersistenceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AttributeKey")
                        .HasMaxLength(100);

                    b.Property<string>("AttributeValue");

                    b.Property<long>("ExecutionPointerId");

                    b.HasKey("PersistenceId");

                    b.HasIndex("ExecutionPointerId");

                    b.ToTable("PersistedExtensionAttribute");

                    b.HasAnnotation("Npgsql:Schema", "wfc");

                    b.HasAnnotation("Npgsql:TableName", "ExtensionAttribute");
                });

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedSubscription", b =>
                {
                    b.Property<long>("PersistenceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EventKey")
                        .HasMaxLength(200);

                    b.Property<string>("EventName")
                        .HasMaxLength(200);

                    b.Property<int>("StepId");

                    b.Property<DateTime>("SubscribeAsOf");

                    b.Property<Guid>("SubscriptionId")
                        .HasMaxLength(200);

                    b.Property<string>("WorkflowId")
                        .HasMaxLength(200);

                    b.HasKey("PersistenceId");

                    b.HasIndex("EventKey");

                    b.HasIndex("EventName");

                    b.HasIndex("SubscriptionId")
                        .IsUnique();

                    b.ToTable("PersistedSubscription");

                    b.HasAnnotation("Npgsql:Schema", "wfc");

                    b.HasAnnotation("Npgsql:TableName", "Subscription");
                });

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedWorkflow", b =>
                {
                    b.Property<long>("PersistenceId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CompleteTime");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Data");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<Guid>("InstanceId")
                        .HasMaxLength(200);

                    b.Property<long?>("NextExecution");

                    b.Property<string>("Reference")
                        .HasMaxLength(200);

                    b.Property<int>("Status");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowDefinitionId")
                        .HasMaxLength(200);

                    b.HasKey("PersistenceId");

                    b.HasIndex("InstanceId")
                        .IsUnique();

                    b.HasIndex("NextExecution");

                    b.ToTable("PersistedWorkflow");

                    b.HasAnnotation("Npgsql:Schema", "wfc");

                    b.HasAnnotation("Npgsql:TableName", "Workflow");
                });

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedExecutionPointer", b =>
                {
                    b.HasOne("WorkflowCore.Persistence.EntityFramework.Models.PersistedWorkflow", "Workflow")
                        .WithMany("ExecutionPointers")
                        .HasForeignKey("WorkflowId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorkflowCore.Persistence.EntityFramework.Models.PersistedExtensionAttribute", b =>
                {
                    b.HasOne("WorkflowCore.Persistence.EntityFramework.Models.PersistedExecutionPointer", "ExecutionPointer")
                        .WithMany("ExtensionAttributes")
                        .HasForeignKey("ExecutionPointerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
