﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nethereum.Mud.Repositories.Postgres;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VisionsContracts.LogProcessing.Postgres.Migrations
{
    [DbContext(typeof(MudPostgresStoreRecordsDbContext))]
    [Migration("20250110084300_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Nethereum.BlockchainProcessing.BlockStorage.Entities.BlockProgress", b =>
                {
                    b.Property<int>("RowIndex")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("rowindex");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RowIndex"));

                    b.Property<string>("LastBlockProcessed")
                        .HasColumnType("text")
                        .HasColumnName("lastblockprocessed");

                    b.Property<DateTime?>("RowCreated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("rowcreated");

                    b.Property<DateTime?>("RowUpdated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("rowupdated");

                    b.HasKey("RowIndex")
                        .HasName("pk_blockprogress");

                    b.ToTable("blockprogress", (string)null);
                });

            modelBuilder.Entity("Nethereum.Mud.TableRepository.StoredRecord", b =>
                {
                    b.Property<byte[]>("AddressBytes")
                        .HasColumnType("bytea")
                        .HasColumnName("address");

                    b.Property<byte[]>("TableIdBytes")
                        .HasColumnType("bytea")
                        .HasColumnName("tableid");

                    b.Property<byte[]>("KeyBytes")
                        .HasColumnType("bytea")
                        .HasColumnName("key");

                    b.Property<decimal?>("BlockNumber")
                        .HasColumnType("numeric(1000, 0)")
                        .HasColumnName("blocknumber");

                    b.Property<byte[]>("DynamicData")
                        .HasColumnType("bytea")
                        .HasColumnName("dynamic_data");

                    b.Property<byte[]>("EncodedLengths")
                        .HasColumnType("bytea")
                        .HasColumnName("encoded_lengths");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("isdeleted");

                    b.Property<byte[]>("Key0Bytes")
                        .HasColumnType("bytea")
                        .HasColumnName("key0");

                    b.Property<byte[]>("Key1Bytes")
                        .HasColumnType("bytea")
                        .HasColumnName("key1");

                    b.Property<byte[]>("Key2Bytes")
                        .HasColumnType("bytea")
                        .HasColumnName("key2");

                    b.Property<byte[]>("Key3Bytes")
                        .HasColumnType("bytea")
                        .HasColumnName("key3");

                    b.Property<int?>("LogIndex")
                        .HasColumnType("integer")
                        .HasColumnName("logindex");

                    b.Property<int>("RowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("rowid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RowId"));

                    b.Property<byte[]>("StaticData")
                        .HasColumnType("bytea")
                        .HasColumnName("static_data");

                    b.HasKey("AddressBytes", "TableIdBytes", "KeyBytes")
                        .HasName("pk_storedrecords");

                    b.HasIndex("RowId")
                        .HasDatabaseName("IX_RowId");

                    b.HasIndex("AddressBytes", "TableIdBytes", "Key0Bytes")
                        .HasDatabaseName("IX_Address_TableId_Key0");

                    b.HasIndex("AddressBytes", "TableIdBytes", "Key1Bytes")
                        .HasDatabaseName("IX_Address_TableId_Key1");

                    b.HasIndex("AddressBytes", "TableIdBytes", "Key2Bytes")
                        .HasDatabaseName("IX_Address_TableId_Key2");

                    b.HasIndex("AddressBytes", "TableIdBytes", "Key3Bytes")
                        .HasDatabaseName("IX_Address_TableId_Key3");

                    b.ToTable("storedrecords", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
