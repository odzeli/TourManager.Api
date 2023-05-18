﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TourManager.Storage;

namespace TourManager.Storage.Migrations
{
    [DbContext(typeof(TourManagerDbContext))]
    partial class TourManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TourManager.Storage.Models.Cell", b =>
                {
                    b.Property<Guid>("ColumnId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TouristId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("BoolValue")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DateTimeValue")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("DecimalValue")
                        .HasColumnType("decimal(18,4)");

                    b.Property<Guid?>("GuidValue")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("IntValue")
                        .HasColumnType("int");

                    b.Property<string>("StringValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ColumnId", "TouristId");

                    b.HasIndex("TouristId");

                    b.ToTable("Cell");
                });

            modelBuilder.Entity("TourManager.Storage.Models.Column", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ColumnId");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DefaultAccess")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Options")
                        .HasColumnType("int");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<Guid>("TourId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ValueType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.ToTable("Column");
                });

            modelBuilder.Entity("TourManager.Storage.Models.StandardColumn", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("StandardColumnId");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DefaultAccess")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Options")
                        .HasColumnType("int");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<int>("ValueType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("StandardColumn");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6b52973d-171c-47b3-8fb3-7976d9056da6"),
                            Code = "TourStartDate",
                            DefaultAccess = 0,
                            Name = "Начало тура",
                            Options = 2,
                            SortOrder = 0,
                            ValueType = 4
                        },
                        new
                        {
                            Id = new Guid("8d01e4cd-aba4-487e-acb0-f1c4ebf5aa1d"),
                            Code = "TourEndDate",
                            DefaultAccess = 0,
                            Name = "Конец тура",
                            Options = 2,
                            SortOrder = 1,
                            ValueType = 4
                        },
                        new
                        {
                            Id = new Guid("8661aad6-4130-44dd-8f03-5edd405a6144"),
                            Code = "Номер заказа",
                            DefaultAccess = 0,
                            Name = "OrderNumber",
                            Options = 2,
                            SortOrder = 2,
                            ValueType = 2
                        },
                        new
                        {
                            Id = new Guid("37926df9-b966-4f28-9927-0aea4caaa354"),
                            Code = "TourName",
                            DefaultAccess = 0,
                            Name = "Название тура",
                            Options = 2,
                            SortOrder = 3,
                            ValueType = 2
                        },
                        new
                        {
                            Id = new Guid("08e1d00e-85d2-4ea8-b2a6-b4449845fe4c"),
                            Code = "FullName",
                            DefaultAccess = 0,
                            Name = "Имя",
                            Options = 2,
                            SortOrder = 4,
                            ValueType = 2
                        },
                        new
                        {
                            Id = new Guid("72de359f-a758-4179-901c-4830e866e755"),
                            Code = "ArrivingDate",
                            DefaultAccess = 0,
                            Name = "Дата и время приезда",
                            Options = 2,
                            SortOrder = 5,
                            ValueType = 2
                        },
                        new
                        {
                            Id = new Guid("d69856ed-5b91-40dd-b966-66d4ab577be4"),
                            Code = "DepartureDate",
                            DefaultAccess = 0,
                            Name = "Дата и время отъезда",
                            Options = 2,
                            SortOrder = 6,
                            ValueType = 2
                        },
                        new
                        {
                            Id = new Guid("c1fa0201-c634-47dc-89b9-70ff4c0c66af"),
                            Code = "BirthData",
                            DefaultAccess = 0,
                            Name = "Дата рождения",
                            Options = 2,
                            SortOrder = 7,
                            ValueType = 4
                        },
                        new
                        {
                            Id = new Guid("35d88ff3-8ad6-47c2-9a93-dc1ec1d03f57"),
                            Code = "PhoneNumber",
                            DefaultAccess = 0,
                            Name = "Номер телефона",
                            Options = 2,
                            SortOrder = 8,
                            ValueType = 2
                        },
                        new
                        {
                            Id = new Guid("638d7910-902e-48ce-a671-0d2729916e09"),
                            Code = "PassportId",
                            DefaultAccess = 0,
                            Name = "Номер паспорта",
                            Options = 2,
                            SortOrder = 9,
                            ValueType = 2
                        },
                        new
                        {
                            Id = new Guid("84f31ee3-19a4-4058-82b5-2bfa17ad6c89"),
                            Code = "Comment",
                            DefaultAccess = 0,
                            Name = "Коментарии",
                            Options = 2,
                            SortOrder = 10,
                            ValueType = 2
                        },
                        new
                        {
                            Id = new Guid("3a8805ee-97cf-4a55-baf4-e1fddb05e61d"),
                            Code = "Accommodation",
                            DefaultAccess = 0,
                            Name = "Отель",
                            Options = 2,
                            SortOrder = 11,
                            ValueType = 2
                        });
                });

            modelBuilder.Entity("TourManager.Storage.Models.Tour", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TourId");

                    b.Property<string>("Drivers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Expenses")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Guides")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tour");
                });

            modelBuilder.Entity("TourManager.Storage.Models.Tourist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TouristId");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TourId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.ToTable("Tourist");
                });

            modelBuilder.Entity("TourManager.Storage.Models.Cell", b =>
                {
                    b.HasOne("TourManager.Storage.Models.Column", null)
                        .WithMany()
                        .HasForeignKey("ColumnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourManager.Storage.Models.Tourist", null)
                        .WithMany()
                        .HasForeignKey("TouristId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TourManager.Storage.Models.Column", b =>
                {
                    b.HasOne("TourManager.Storage.Models.Tour", null)
                        .WithMany()
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TourManager.Storage.Models.Tourist", b =>
                {
                    b.HasOne("TourManager.Storage.Models.Tour", null)
                        .WithMany()
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
