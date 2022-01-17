﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TourManager.Storage;

namespace TourManager.Storage.Migrations
{
    [DbContext(typeof(TourManagerDbContext))]
    [Migration("20220113181111_Update_column_values")]
    partial class Update_column_values
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StandardColumnId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                            Id = 1,
                            Code = "name",
                            DefaultAccess = 0,
                            Name = "Имя",
                            Options = 2,
                            SortOrder = 0,
                            ValueType = 2
                        },
                        new
                        {
                            Id = 2,
                            Code = "startDate",
                            DefaultAccess = 0,
                            Name = "Начало тура",
                            Options = 2,
                            SortOrder = 1,
                            ValueType = 4
                        },
                        new
                        {
                            Id = 3,
                            Code = "endDate",
                            DefaultAccess = 0,
                            Name = "Конец тура",
                            Options = 2,
                            SortOrder = 3,
                            ValueType = 4
                        },
                        new
                        {
                            Id = 4,
                            Code = "daysNumber",
                            DefaultAccess = 0,
                            Name = "Дней в туре",
                            Options = 2,
                            SortOrder = 4,
                            ValueType = 1
                        },
                        new
                        {
                            Id = 5,
                            Code = "nightsInHotel",
                            DefaultAccess = 0,
                            Name = "Ночей в отеле",
                            Options = 2,
                            SortOrder = 5,
                            ValueType = 1
                        },
                        new
                        {
                            Id = 6,
                            Code = "tourStars",
                            DefaultAccess = 0,
                            Name = "Категория тура",
                            Options = 2,
                            SortOrder = 6,
                            ValueType = 1
                        },
                        new
                        {
                            Id = 7,
                            Code = "roomType",
                            DefaultAccess = 0,
                            Name = "Тип номера",
                            Options = 2,
                            SortOrder = 7,
                            ValueType = 2
                        },
                        new
                        {
                            Id = 8,
                            Code = "phone",
                            DefaultAccess = 0,
                            Name = "Номер телефона",
                            Options = 2,
                            SortOrder = 8,
                            ValueType = 2
                        },
                        new
                        {
                            Id = 9,
                            Code = "hotel",
                            DefaultAccess = 0,
                            Name = "Отель",
                            Options = 2,
                            SortOrder = 9,
                            ValueType = 2
                        },
                        new
                        {
                            Id = 10,
                            Code = "closedPrice",
                            DefaultAccess = 0,
                            Name = "Закрытая цена",
                            Options = 2,
                            SortOrder = 10,
                            ValueType = 3
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

                    b.Property<string>("Guides")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

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
